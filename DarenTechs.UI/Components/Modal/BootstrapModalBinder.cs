using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DarenTechs.UI.Components.Modal
{
    public class BootstrapModalBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var values = bindingContext.ValueProvider.GetValue("bootstrapmodal");
            if (values.Length == 0)
                return Task.CompletedTask;

            var result = JsonConvert.DeserializeObject<BootstrapModal>(values.FirstValue);
            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }
    }
}
