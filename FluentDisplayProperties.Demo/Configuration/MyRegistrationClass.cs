using FluentDisplayProperties.Registration;

namespace FluentDisplayProperties.Demo.Configuration
{
    public class MyRegistrationClass : BaseFluentDisplayPropertiesRegistration
    {
        public MyRegistrationClass()
        {
            this.AllowDisplayAnnotations = true;
        }

        protected override void OnRegistration(DisplayPropertyFactory factory)
        {
            factory.Register(new ExampleModelProperties());
        }
    }
}