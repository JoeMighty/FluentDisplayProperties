using FluentDisplayProperties.Demo.ViewModels;

namespace FluentDisplayProperties.Demo.Configuration
{
    public class ExampleModelProperties : DisplayPropertyConfiguration<ExampleViewModel>
    {
        public ExampleModelProperties()
        {
            this.Property(x => x.FullName).Display("Joe's Name");
            this.Property(x => x.Address1).Display("Primary Address");
            this.Property(x => x.Address2).Display("Secondary Address");
            /*this.Property(x => x.AddressLine3).Display("Secondary Address 3");*/
            this.Property(x => x.TownCity).Display("Town / City");
        }
    }
}