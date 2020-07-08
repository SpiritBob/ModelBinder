using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnknownModelBindersExample.ModelBinders
{
    public class StringBinderProvider : IModelBinderProvider
    {
       // Gets hit multiple times - once where context.MetaData.ModelType is equal to `ExampleObject`, and then for each of its properties
       // Why does this happen? Shouldn't it be hit only once with the complex type, and if no binder is provided - to provide one for each of its properties?
       // What would happen if you provide a binder for the complex type and then for each of the properties - which one does its job first?
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.Metadata.ModelType == typeof(string)
                    && context.BindingInfo.BindingSource is null // What are we capturing here that has a null BindingSource?
                ? new StringBinder()
                : null;
        }
    }
}
