using FluentDisplayProperties.MetaData;
using FluentDisplayProperties.ResourceProvider;

namespace FluentDisplayProperties.Registration
{
    public class BaseFluentDisplayPropertiesRegistration
    {
        public bool AllowDisplayAnnotations { get; set; }

        public DisplayPropertyResourceProvider ResourceProvider { get; set; }

        public FluentDisplayPropertiesProvider GetProvider()
        {
            var factory = new DisplayPropertyContainer();
            OnRegistration(factory);

            return new FluentDisplayPropertiesProvider(factory, this.ResourceProvider, this.AllowDisplayAnnotations);
        }

        protected virtual void OnRegistration(DisplayPropertyContainer propertyContainer)
        {
        }
    }
}