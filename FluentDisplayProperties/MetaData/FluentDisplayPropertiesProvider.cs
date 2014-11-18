using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentDisplayProperties.ResourceProvider;

namespace FluentDisplayProperties.MetaData
{
    public class FluentDisplayPropertiesProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly bool allowDisplayAnnotations;
        private DisplayPropertyContainer propertyContainer;
        private readonly IResourceProvider ResourceProvider;

        /*http://haacked.com/archive/2011/07/14/model-metadata-and-validation-localization-using-conventions.aspx/*/

        public FluentDisplayPropertiesProvider(DisplayPropertyContainer propertyContainer, IResourceProvider resourceProvider, bool allowDisplayAnnotations = true)
        {
            this.propertyContainer = propertyContainer;
            this.allowDisplayAnnotations = allowDisplayAnnotations;
            this.ResourceProvider = resourceProvider;
        }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            
            // Render display annotation instead
            if (this.allowDisplayAnnotations && PropertyHasDisplayAttribute(metadata))
            {
                return metadata;
            }

            // Lookup resource
            string propertyValue;
            if (this.ResourceProvider != null && this.ResourceProvider.TryLookupResource(metadata.PropertyName, out propertyValue))
            {
                metadata.DisplayName = propertyValue;
                return metadata;
            }

            // Return from container, or split word
            string key = containerType.FullName + "." + metadata.PropertyName;

            IDisplayProperty displayProperty;
            metadata.DisplayName = DisplayPropertyContainer.DisplayProperties.TryGetValue(key, out displayProperty) ? displayProperty.DisplayValue : metadata.PropertyName.ToSeparatedWords();

            return metadata;
        }

        private static bool PropertyHasDisplayAttribute(ModelMetadata metadata)
        {
            return (metadata.DisplayName != null);
        }
    }
}