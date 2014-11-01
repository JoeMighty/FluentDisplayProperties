using System.Reflection;

namespace FluentDisplayProperties
{
    public interface IDisplayProperty
    {
        string DisplayValue { get; set; }

        string PropertyName { get; set; }

        PropertyInfo PropertyInformation { get; set; }
    }
}