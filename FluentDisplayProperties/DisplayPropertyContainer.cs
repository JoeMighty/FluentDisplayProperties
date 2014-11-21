using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentDisplayProperties
{
    public class DisplayPropertyContainer
    {
        private static readonly Dictionary<string, IDisplayProperty> DisplayPropertiesContainer = new Dictionary<string, IDisplayProperty>();

        public static bool TryGetDisplayProperty(string type, out IDisplayProperty displayProperty)
        {
            IDisplayProperty property;
            if (DisplayPropertiesContainer.TryGetValue(type, out property))
            {
                displayProperty = property;
                return true;
            }

            displayProperty = null;
            return false;
        }

        public static void RegisterProperty(IDisplayProperty displayProperty)
        {
            /*string property = property.DeclaringType.AssemblyQualifiedName;*/

            PropertyInfo propertyInfo = displayProperty.PropertyInformation;
            var propertyKey = propertyInfo.DeclaringType.FullName + "." + propertyInfo.Name;

            if (!DisplayPropertiesContainer.ContainsKey(propertyKey))
            {
                DisplayPropertiesContainer.Add(propertyKey, displayProperty);    
            }
        }

        /*public void Register<TDisplayPropertyType>(DisplayPropertyConfiguration<TDisplayPropertyType> entityTypeConfiguration) where TDisplayPropertyType : class
        {

        }*/

        public void Register(Type modelType)
        {
            Activator.CreateInstance(modelType);
        }
    }
}