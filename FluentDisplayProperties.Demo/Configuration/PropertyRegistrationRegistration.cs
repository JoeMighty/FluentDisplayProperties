using FluentDisplayProperties.Registration;

namespace FluentDisplayProperties.Demo.Configuration
{
    public class PropertyRegistrationRegistration : BaseFluentDisplayPropertiesRegistration
    {
        public PropertyRegistrationRegistration()
        {
            this.AllowDisplayAnnotations = true;
        }

        protected override void OnRegistration(DisplayPropertyFactory factory)
        {
            factory.Register(new ExampleModelProperties());
        }
    }
}