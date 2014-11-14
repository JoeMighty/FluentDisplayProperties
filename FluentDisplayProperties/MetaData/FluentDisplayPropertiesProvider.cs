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

            if (this.ResourceProvider != null)
            {
                metadata.DisplayName = this.ResourceProvider.ResourceLookup(metadata.PropertyName);

                return metadata;
            }

            string key = containerType.FullName + "." + metadata.PropertyName;

            IDisplayProperty displayProperty;
            if (DisplayPropertyContainer.DisplayProperties.TryGetValue(key, out displayProperty))
            {
                // Use property from container
                metadata.DisplayName = displayProperty.DisplayValue;
            }
            else if (!this.allowDisplayAnnotations)
            {
                // Fall back to the separated, property name
                metadata.DisplayName = metadata.PropertyName.ToSeparatedWords();
            }

            return metadata;
        }

        private static bool PropertyHasDisplayAttribute(ModelMetadata metadata)
        {
            return (metadata.DisplayName != null);
        }
    }
}