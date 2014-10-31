namespace FluentDisplayProperties.Demo.ViewModels
{
    public class ExampleViewModel
    {
        public string Title { get; set; }

        public string FullName { get; set; }

        public string Surname { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }
    }
}

/*public class ExampleViewModel
{
    public string Name { get; set; } // Output as "Name"

    public string FullName { get; set; } // Output as "FullName"

    [DisplayName("Telephone Number")]
    public string TelephoneNumber { get; set; }
}*/