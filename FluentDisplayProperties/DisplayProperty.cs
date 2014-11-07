using System.Reflection;

namespace FluentDisplayProperties
{
    public class DisplayProperty : IDisplayProperty
    {
        public DisplayProperty(PropertyInfo propertyInfo)
        {
            this.PropertyInformation = propertyInfo;
            this.PropertyName = propertyInfo.Name;
        }

        public string DisplayValue { get; set; }

        public string PropertyName { get; set; }

        public PropertyInfo PropertyInformation { get; set; }
    }
}