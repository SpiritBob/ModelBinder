using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnknownModelBindersExample.ModelBinders
{
    public class StringBinderProvider : IModelBinderProvider
    {
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
