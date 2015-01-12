namespace FluentDisplayProperties.ResourceProvider
{
    public abstract class DisplayPropertyResourceProvider
    {
        public bool AllowAnnotations { get; set; }

        public DisplayPropertyContainer PropertyContainer { get; set; }

        public abstract string LookupResource(ResourceItem resourceItem);
    }
}