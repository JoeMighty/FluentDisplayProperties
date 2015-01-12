using FluentDisplayProperties.MetaData;
using FluentDisplayProperties.ResourceProvider;

namespace FluentDisplayProperties.Registration
{
    public abstract class BaseFluentDisplayPropertiesRegistration
    {
        // public configuration options that can be set when bootstrapped within global.asax.cs
        public bool AllowDisplayAnnotations { get; set; }
        public DisplayPropertyResourceProvider ResourceProvider { get; set; }

        public FluentDisplayPropertiesProvider GetProvider()
        {
            // Call overridden configuration registration to setup viewmodel configs, ie:
            /*protected override void OnRegistration(DisplayPropertyContainer propertyContainer)
            {
                propertyContainer.Register<ExampleModelProperties>();
            }*/

            var propertyContainer = new DisplayPropertyContainer();
            OnRegistration(propertyContainer);

            // This is where we get all of the view models registered and then add them into a collection for later use
            return new FluentDisplayPropertiesProvider(propertyContainer, this.ResourceProvider, this.AllowDisplayAnnotations);
        }

        protected virtual void OnRegistration(DisplayPropertyContainer propertyContainer)
        {
            // Overridden
        }
    }
}