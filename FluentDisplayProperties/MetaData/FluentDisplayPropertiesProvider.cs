using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FluentDisplayProperties.MetaData
{
    public class FluentDisplayPropertiesProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            string key = containerType.FullName + "." + metadata.PropertyName;

            IDisplayProperty displayProperty;

            var res = DisplayPropertyFactory.DisplayProperties;

            if (DisplayPropertyFactory.DisplayProperties.TryGetValue(key, out displayProperty))
            {
                metadata.DisplayName = displayProperty.DisplayValue;
            } else if (metadata.DisplayName == null)
            {
                metadata.DisplayName = metadata.PropertyName.ToSeparatedWords();
            }

            return metadata;
        }
    }
}