using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentDisplayProperties
{
    public abstract class DisplayPropertyConfiguration<TModel> where TModel : class
    {
        public PropertyInstance<TProp> Property<TProp>(Expression<Func<TModel, TProp>> expression) where TProp : class
        {
            PropertyInfo property = (PropertyInfo) (((MemberExpression) expression.Body).Member);

            /*string res1 = property.Name;
            string res2 = property.DeclaringType.AssemblyQualifiedName;*/

            var fullName = property.DeclaringType.FullName + "." + property.Name;

            var displayProperty = new DisplayProperty(property.Name, property);

            DisplayPropertyFactory.DisplayProperties.Add(fullName, displayProperty);

            return new PropertyInstance<TProp>(displayProperty);
        }
    }
}
