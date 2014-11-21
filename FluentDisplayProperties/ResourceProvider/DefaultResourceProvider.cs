namespace FluentDisplayProperties.ResourceProvider
{
    public class DefaultResourceProvider : DisplayPropertyResourceProvider
    {
        public override string LookupResource(ResourceItem resourceItem, string propertyKey)
        {
            // Return from container, or split word
            string key = resourceItem.FullName + "." + resourceItem.PropertyName;

            IDisplayProperty displayProperty;
            string displayName = DisplayPropertyContainer.TryGetDisplayProperty(key, out displayProperty) ? displayProperty.DisplayValue : resourceItem.PropertyName.ToSeparatedWords();

            return displayName;
        }
    }
}