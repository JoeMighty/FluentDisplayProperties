using System;
using System.Collections.Generic;

namespace FluentDisplayProperties
{
    public class DisplayPropertyFactory
    {
        public static Dictionary<string, IDisplayProperty> DisplayProperties = new Dictionary<string, IDisplayProperty>();

        public IDisplayProperty GetDisplayProperty(string type)
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