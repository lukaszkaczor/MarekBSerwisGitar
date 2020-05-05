using System.Collections.Generic;
using System.Security.AccessControl;
using SerwisGitar.Models;
using SerwisGitar.Models.AppModels;

namespace SerwisGitar.ViewModels.ContentEditor
{
    public class ContentEditorViewModel
    {
        public Models.DbModels.ContentEditor ContentEditor { get; set; }
        public List<PageDescription> Pages { get; set; }
        //public Page Page { get; set; }
    }
}