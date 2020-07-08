using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace UnknownModelBindersExample.ModelBinders
{
    public class StringBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            // Add to model dictionary
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            bindingContext.Result = ModelBindingResult.Success(valueProviderResult.FirstValue + ". I modified you.");
            return Task.CompletedTask;
        }
    }
}
