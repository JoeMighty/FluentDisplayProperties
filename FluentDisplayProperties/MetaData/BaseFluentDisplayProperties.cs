namespace FluentDisplayProperties.MetaData
{
    public class BaseFluentDisplayProperties
    {
        public FluentDisplayPropertiesProvider Register(bool allowDisplayAnnotations)
        {
            var provider = new FluentDisplayPropertiesProvider(allowDisplayAnnotations);

            RegisterProperties(provider);

            return provider;
        }

        protected virtual void RegisterProperties(FluentDisplayPropertiesProvider modelBuilder)
        {
        }
    }
}