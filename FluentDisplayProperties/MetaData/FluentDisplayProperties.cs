namespace FluentDisplayProperties.MetaData
{
    public static class FluentDisplayProperties
    {
        public static FluentDisplayPropertiesProvider Register(bool allowDisplayAnnotations)
        {
            return new FluentDisplayPropertiesProvider(allowDisplayAnnotations);
        }
    }
}