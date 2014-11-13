using FluentDisplayProperties.MetaData;
using FluentDisplayProperties.ResourceProvider;

namespace FluentDisplayProperties.Registration
{
    public class BaseFluentDisplayPropertiesRegistration
    {
        public bool AllowDisplayAnnotations { get; set; }

        public IResourceProvider ResourceProvider { get; set; }

        public FluentDisplayPropertiesProvider GetProvider()
        {
            var factory = new DisplayPropertyFactory();

            OnRegistration(factory);

            return new FluentDisplayPropertiesProvider(factory, this.AllowDisplayAnnotations);
        }

        protected virtual void OnRegistration(DisplayPropertyFactory modelBuilder)
        {
        }
    }
}