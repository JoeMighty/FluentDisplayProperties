using System;
using System.Collections.Generic;

namespace FluentDisplayProperties
{
    public class DisplayPropertyFactory
    {
        public static Dictionary<Type, IDisplayProperty> DisplayProperties = new Dictionary<Type, IDisplayProperty>();

        public IDisplayProperty GetDisplayProperty(Type type)
        {
            IDisplayProperty property;
            if (DisplayProperties.TryGetValue(type, out property))
            {
                return property;
            }

            return null;
        }
    }
}