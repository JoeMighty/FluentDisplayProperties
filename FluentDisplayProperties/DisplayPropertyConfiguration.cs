using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentDisplayProperties
{
    public abstract class DisplayPropertyConfiguration<TModel> where TModel : class
    {


        public PropertyInstance<TProp> Property<TProp>(Expression<Func<TModel, TProp>> expression) where TProp : class
        {
            var displayProperty = new DisplayProperty();
            var instance = new PropertyInstance<TProp>(displayProperty);

            DisplayPropertyFactory.DisplayProperties.Add(typeof (TModel), displayProperty);

            return new PropertyInstance<TProp>(displayProperty);
        }
    }
}
