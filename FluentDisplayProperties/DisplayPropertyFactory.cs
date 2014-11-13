using System.Collections.Generic;

namespace FluentDisplayProperties
{
    public class DisplayPropertyFactory : IDisplayPropertyFactory
    {
        private static readonly Dictionary<string, IDisplayProperty> DisplayPropertiesContainer = new Dictionary<string, IDisplayProperty>();

        //TODO: Return container for Dictionary removing any access allowing for custom API to collection
        public static Dictionary<string, IDisplayProperty> DisplayProperties
        {
            get { return DisplayPropertiesContainer; }
        }

        private static IDisplayProperty GetDisplayProperty(string type)
        {
            IDisplayProperty property;
            if (DisplayProperties.TryGetValue(type, out property))
            {
                return property;
            }

            return null;
        }

        public static void RegisterProperty(DisplayProperty displayProperty)
        {
            /*string res1 = property.Name;
            string res2 = property.DeclaringType.AssemblyQualifiedName;*/

            var property = displayProperty.PropertyInformation;

            var fullName = property.DeclaringType.FullName + "." + property.Name;
            DisplayProperties.Add(fullName, displayProperty);
        }

        public void Register<TDisplayPropertyType>(DisplayPropertyConfiguration<TDisplayPropertyType> entityTypeConfiguration) where TDisplayPropertyType : class
        {

        }
    }
}