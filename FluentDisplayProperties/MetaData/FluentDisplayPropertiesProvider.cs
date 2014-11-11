using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FluentDisplayProperties.MetaData
{
    public class FluentDisplayPropertiesProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly bool allowDisplayAnnotations;
        private IDisplayPropertyFactory displayPropertyFactory;

        /*http://haacked.com/archive/2011/07/14/model-metadata-and-validation-localization-using-conventions.aspx/*/

        public FluentDisplayPropertiesProvider(IDisplayPropertyFactory displayPropertyFactory, bool allowDisplayAnnotations = true)
        {
            this.displayPropertyFactory = displayPropertyFactory;
            this.allowDisplayAnnotations = allowDisplayAnnotations;
        }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (this.allowDisplayAnnotations && this.PropertyHasDisplayAttribute(metadata))
            {
                return metadata;
            }

            string key = containerType.FullName + "." + metadata.PropertyName;

            IDisplayProperty displayProperty;
            if (DisplayPropertyFactory.DisplayProperties.TryGetValue(key, out displayProperty))
            {
                metadata.DisplayName = displayProperty.DisplayValue;
            }
            else if (!this.allowDisplayAnnotations)
            {
                metadata.DisplayName = metadata.PropertyName.ToSeparatedWords();
            }

            return metadata;
        }

        private bool PropertyHasDisplayAttribute(ModelMetadata metadata)
        {
            return (metadata.DisplayName != null);
        }
    }
}