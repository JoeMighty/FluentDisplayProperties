using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FluentDisplayProperties.MetaData
{
    public class FluentDisplayPropertiesProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType,
            Func<object> modelAccessor, Type modelType, string propertyName)
        {
            ModelMetadata metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            var key = containerType.FullName + "." + metadata.PropertyName;
            
            IDisplayProperty displayProperty;
            var res = DisplayPropertyFactory.DisplayProperties.TryGetValue(key, out displayProperty);
            metadata.DisplayName = displayProperty.DisplayValue;


            /*if (DisplayPropertyFactory.DisplayProperties.TryGetValue(containerType, out property))
            {
                metadata.DisplayName = property.DisplayValue;
            }*/

            /*if (metadata.DisplayName == null)
            {
                metadata.DisplayName = metadata.PropertyName.ToSeparatedWords();
            }*/

            return metadata;
        }
    }
}