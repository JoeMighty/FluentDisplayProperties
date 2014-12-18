namespace FluentDisplayProperties.ResourceProvider
{
    public class DefaultResourceProvider : DisplayPropertyResourceProvider
    {
        public override string LookupResource(ResourceItem resourceItem, string propertyKey)
        {
            // Return from container, or split word
            string key = resourceItem.FullName + "." + resourceItem.PropertyName;

            IDisplayProperty displayProperty;
            /*string displayName = DisplayPropertyContainer.TryGetDisplayProperty(key, out displayProperty) ? displayProperty.DisplayValue : resourceItem.PropertyName.ToSeparatedWords();*/
            bool exists = DisplayPropertyContainer.DoesDisplayModelExist(resourceItem.PropertyKey2);
            if (exists)
            {
                // new up display model    
            }

            /**string displayName = DisplayPropertyContainer.TryGetDisplayProperty(key, out displayProperty) ? displayProperty.DisplayValue : resourceItem.PropertyName.ToSeparatedWords();**/

            return "";
        }
    }
}