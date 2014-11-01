using System.Reflection;

namespace FluentDisplayProperties
{
    public class DisplayProperty : IDisplayProperty
    {
        public DisplayProperty(string propertyName, PropertyInfo propertyInfo)
        {
            this.PropertyInformation = propertyInfo;
            this.PropertyName = propertyName;
        }

        public string DisplayValue { get; set; }

        public string PropertyName { get; set; }

        public PropertyInfo PropertyInformation { get; set; }
    }
}