using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentDisplayProperties.ResourceProvider;

namespace FluentDisplayProperties.MetaData
{
    public class FluentDisplayPropertiesProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly bool allowDisplayAnnotations;
        private readonly DisplayPropertyResourceProvider ResourceProvider;

        public FluentDisplayPropertiesProvider(DisplayPropertyContainer propertyContainer, DisplayPropertyResourceProvider resourceProvider, bool allowDisplayAnnotations = true)
        {
            this.allowDisplayAnnotations = allowDisplayAnnotations;

            this.ResourceProvider = resourceProvider;
            this.ResourceProvider.PropertyContainer = propertyContainer;
            this.ResourceProvider.AllowAnnotations = allowDisplayAnnotations;
        }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (this.allowDisplayAnnotations && PropertyHasDisplayAttribute(metadata))
            {
                return metadata;
            }

            var resourceItem = new ResourceItem
            {
                DisplayName = metadata.DisplayName,
                FullName = containerType.FullName,
                PropertyKey = containerType.FullName + "." + metadata.PropertyName,
                PropertyName = metadata.PropertyName
            };

            metadata.DisplayName = this.ResourceProvider.LookupResource(resourceItem, resourceItem.PropertyKey);

            return metadata;
        }

        private static bool PropertyHasDisplayAttribute(ModelMetadata metadata)
        {
            return (metadata.DisplayName != null);
        }
    }
}