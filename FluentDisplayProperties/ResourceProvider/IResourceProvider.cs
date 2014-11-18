namespace FluentDisplayProperties.ResourceProvider
{
    public interface IResourceProvider
    {
        bool TryLookupResource(string propertyName, out string propertyValue);
    }
}