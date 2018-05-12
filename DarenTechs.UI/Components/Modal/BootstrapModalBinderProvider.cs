using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace DarenTechs.UI.Components.Modal
{
    public class BootstrapModalBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(BootstrapModal))
                return new BootstrapModalBinder();

            return null;
        }
    }
}
