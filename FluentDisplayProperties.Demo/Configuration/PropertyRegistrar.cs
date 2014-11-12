using FluentDisplayProperties.MetaData;
using FluentDisplayProperties.Registration;

namespace FluentDisplayProperties.Demo.Configuration
{
    public class PropertyRegistrar
    {
        public static FluentDisplayPropertiesProvider Register(BaseFluentDisplayPropertiesRegistration registrar)
        {
            return registrar.GetProvider();
        } 
    }
}