namespace FluentDisplayProperties.ResourceProvider
{
    public class DefaultResourceProvider : DisplayPropertyResourceProvider
    {
        public override string LookupResource(ResourceItem resourceItem)
        {
            // Return from container, or split word
            string key = resourceItem.FullName + "." + resourceItem.PropertyName;

            IDisplayProperty displayProperty;
            /*string displayName = DisplayPropertyContainer.TryGetDisplayProperty(key, out displayProperty) ? displayProperty.DisplayValue : resourceItem.PropertyName.ToSeparatedWords();*/

            // Try and create an instance of the view model configuration class who's mappings are created within constructor
            bool exists = DisplayPropertyContainer.TryCreateInstanceOfViewModelConfig(resourceItem.PropertyKey2);
            if (exists)
            {
                /*string displayName = DisplayPropertyContainer.TryGetDisplayProperty(key, out displayProperty) ? displayProperty.DisplayValue : resourceItem.PropertyName.ToSeparatedWords();*/
            }

            

            return "";
        }
    }
}