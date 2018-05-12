using Microsoft.AspNetCore.Mvc;

namespace DarenTechs.UI.Components.Modal
{
    [ModelBinder(BinderType = typeof(BootstrapModalBinder))]
    public class BootstrapModal
    {
        public string Id { get; set; }

        public string RelatedTarget { get; set; }

        public string SelectText { get; set; }

        public ModalFooter Footer { get; set; }
    }
}
