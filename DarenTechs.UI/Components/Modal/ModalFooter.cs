namespace DarenTechs.UI.Components.Modal
{
    public class ModalFooter
    {
        public string SaveButtonText { get; set; } = "Save";

        public string SubmitButtonText { get; set; } = "Submit";

        public string CancelButtonText { get; set; } = "Cancel";
        public string SaveButtonID { get; set; } = "footer-btn-save";

        public SaveButtonTypeModel SaveButtonType { get; set; } = SaveButtonTypeModel.Submit;

        public string CancelButtonID { get; set; } = "footer-btn-cancel";
        public bool OnlyCancelButton { get; set; }
    }
}
