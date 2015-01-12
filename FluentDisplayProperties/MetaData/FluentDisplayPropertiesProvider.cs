using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentDisplayProperties.ResourceProvider;

namespace FluentDisplayProperties.MetaData
{
    public class FluentDisplayPropertiesProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly DisplayPropertyResourceProvider ResourceProvider;

        public FluentDisplayPropertiesProvider(DisplayPropertyContainer propertyContainer, DisplayPropertyResourceProvider resourceProvider, bool allowDisplayAnnotations = true)
        {
            this.ResourceProvider = resourceProvider;
            this.ResourceProvider.PropertyContainer = propertyContainer;
            this.ResourceProvider.AllowAnnotations = allowDisplayAnnotations;
        }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (this.ResourceProvider.AllowAnnotations && PropertyHasDisplayAttribute(metadata))
            {
                return metadata;
            }

            metadata.DisplayName = this.GetOrAddResourceFromProviderProvided(metadata, containerType);

            return metadata;
        }

        private string GetOrAddResourceFromProviderProvided(ModelMetadata metadata, Type containerType)
        {
            var resourceItem = new ResourceItem
            {
                DisplayName = metadata.DisplayName,
                FullName = containerType.FullName,
                PropertyKey = containerType.FullName + "." + metadata.PropertyName,
                PropertyKey2 = containerType.AssemblyQualifiedName,
                PropertyName = metadata.PropertyName
            };

            return this.ResourceProvider.LookupResource(resourceItem);
        }

        private static bool PropertyHasDisplayAttribute(ModelMetadata metadata)
        {
            return (metadata.DisplayName != null);
        }
    }
}