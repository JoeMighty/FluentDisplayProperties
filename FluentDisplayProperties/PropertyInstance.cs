namespace FluentDisplayProperties
{
    public class PropertyInstance<TProp> where TProp : class
    {
        private readonly IDisplayProperty displayProperty;

        public PropertyInstance(IDisplayProperty displayProperty)
        {
            this.displayProperty = displayProperty;
        }

        public void Display(object value)
        {
            this.displayProperty.DisplayValue = value.ToString();
        }

        public void Display(string value)
        {
            this.displayProperty.DisplayValue = value;
        }

        /*public void UseResourceProvider()
        {
        }*/
    }
}