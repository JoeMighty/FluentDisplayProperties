namespace FluentDisplayProperties.ResourceProvider
{
    public class DefaultResourceProvider : IResourceProvider
    {
        public bool TryLookupResource(string propetyName, out string propertyValue)
        {
            propertyValue = string.Empty;
            if (propetyName == "Surname")
            {
                propertyValue = "Hello world!";
            }

            return true;
        }
    }
}