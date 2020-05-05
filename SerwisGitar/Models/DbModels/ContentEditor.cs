using System.Web.Mvc;

namespace SerwisGitar.Models.DbModels
{
    public class ContentEditor
    {
        public int ContentEditorId { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        public Page Page { get; set; }
        public bool IsDraftVersion { get; set; } = false;
    }
}