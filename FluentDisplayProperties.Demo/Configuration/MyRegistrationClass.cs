using FluentDisplayProperties.Registration;
using FluentDisplayProperties.ResourceProvider;

namespace FluentDisplayProperties.Demo.Configuration
{
    public class MyRegistrationClass : BaseFluentDisplayPropertiesRegistration
    {
        public MyRegistrationClass()
        {
            this.AllowDisplayAnnotations = true;
            this.ResourceProvider = new DefaultResourceProvider();
        }

        protected override void OnRegistration(DisplayPropertyContainer propertyContainer)
        {
            propertyContainer.Register(new ExampleModelProperties());
        }
    }
}