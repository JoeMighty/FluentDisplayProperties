using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentDisplayProperties
{
    public class DisplayPropertyContainer
    {
        private static readonly Dictionary<string, IDisplayProperty> DisplayPropertiesContainer = new Dictionary<string, IDisplayProperty>();
        private static readonly Dictionary<string, string> TypeContainer = new Dictionary<string, string>();

        public static bool DoesDisplayModelExist(string key)
        {
            string modelRegistrar = null;
            bool exists = TypeContainer.TryGetValue(key, out modelRegistrar);
            if (exists)
            {
                Type objType = Type.GetType(modelRegistrar);
                object obj = Activator.CreateInstance(objType);
            }

            return true;
        }

/*
        public static bool TryGetDisplayPropertyOld(string type, out IDisplayProperty displayProperty)
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
*/

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

        public void Register<T>()
        {
            /* Register type with container
             * http://stackoverflow.com/questions/2247598/c-sharp-instantiate-class-from-string
             */
            var registrationBase = typeof(T).BaseType;
            if (registrationBase == null) return;

            foreach (var genericArgument in registrationBase.GetGenericArguments())
            {
                if (genericArgument.AssemblyQualifiedName != null)
                {
                    TypeContainer.Add(key: genericArgument.AssemblyQualifiedName, value: typeof(T).AssemblyQualifiedName);
                }
            }
            /*Activator.CreateInstance(typeof(T));*/
        }
    }
}