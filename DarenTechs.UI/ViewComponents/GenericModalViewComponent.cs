using Microsoft.AspNetCore.Mvc;
using DarenTechs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarenTechs.UI.Components.Modal;

namespace DarenTechs.UI.ViewComponents
{
    public class GenericModalViewComponent : ViewComponent
    {

        public GenericModalViewComponent()
        {         
        }

        public Task<IViewComponentResult> InvokeAsync(BootstrapModal bootstrapModal)
        {
            return Task.FromResult<IViewComponentResult>(View(bootstrapModal));
        }

    }
}
