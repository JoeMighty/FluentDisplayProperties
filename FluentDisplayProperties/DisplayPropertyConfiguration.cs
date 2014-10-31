using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentDisplayProperties
{
    public abstract class DisplayPropertyConfiguration<TModel> where TModel : class
    {


        public PropertyInstance<TProp> Property<TProp>(Expression<Func<TModel, TProp>> expression) where TProp : class
        {

            var property = (PropertyInfo)(((MemberExpression)expression.Body).Member);

            var res1 = property.Name;
            var res2 = property.DeclaringType.AssemblyQualifiedName;

            var fullName = property.DeclaringType.FullName + "." + property.Name;

            var displayProperty = new DisplayProperty();

            /*var prop = ((MemberExpression) expression.Body).Member;*/

            DisplayPropertyFactory.DisplayProperties.Add(fullName, displayProperty);

            return new PropertyInstance<TProp>(displayProperty);
        }

        public Type GetObjectType<T>(Expression<Func<T, object>> expr)
        {
            if ((expr.Body.NodeType == ExpressionType.Convert) ||
                (expr.Body.NodeType == ExpressionType.ConvertChecked))
            {
                var unary = expr.Body as UnaryExpression;
                if (unary != null)
                    return unary.Operand.Type;
            }
            return expr.Body.Type;
        }

    }
}
