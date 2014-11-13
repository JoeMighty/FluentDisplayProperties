using FluentDisplayProperties.MetaData;

namespace FluentDisplayProperties.Registration
{
    public class PropertyRegistrar
    {
        public static FluentDisplayPropertiesProvider Register(BaseFluentDisplayPropertiesRegistration registrar)
        {
            return registrar.GetProvider();
        } 
    }
}