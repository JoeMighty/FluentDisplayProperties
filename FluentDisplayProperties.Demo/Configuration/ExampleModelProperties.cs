using FluentDisplayProperties.Demo.ViewModels;

namespace FluentDisplayProperties.Demo.Configuration
{
    public class ExampleModelProperties : DisplayPropertyConfiguration<ExampleViewModel>
    {
        public ExampleModelProperties()
        {
            this.ForProperty(x => x.FullName).Display("Joe's Name");
            this.ForProperty(x => x.FullName).Display("Joe's Name2");
            this.ForProperty(x => x.Surname).Display("Joe's Surname");
            this.ForProperty(x => x.Address1).Display("Primary Address");
            this.ForProperty(x => x.Address2).Display("Secondary Address 222555");
            /*this.Property(x => x.AddressLine3).Display("Secondary Address 3");*/
            this.ForProperty(x => x.TownCity).Display("Town / City");
        }
    }
}