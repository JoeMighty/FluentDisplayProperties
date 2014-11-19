using System.ComponentModel.DataAnnotations;

namespace FluentDisplayProperties.Demo.ViewModels
{
    public class ExampleViewModel
    {
        public string Title { get; set; }

        /*[Display(Name = "My Full Name Attribute")]*/
        public string FullName { get; set; }

        public string Surname { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string AddressLine3 { get; set; }

        public string TownCity { get; set; }

        public int MySSID { get; set; }
    }
}