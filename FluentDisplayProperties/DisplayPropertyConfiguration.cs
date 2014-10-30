using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentDisplayProperties
{
    public abstract class DisplayPropertyConfiguration<TModel> where TModel : class
    {
        public PropertyInstance<TProp> Property<TProp>(Expression<Func<TModel, TProp>> expression) where TProp : class
        {
            DisplayPropertyFactory.DisplayProperties.Add();

            return new PropertyInstance<TProp>();
        }
    }
}
