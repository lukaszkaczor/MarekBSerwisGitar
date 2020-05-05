using System.Collections.Generic;

namespace SerwisGitar.Models.AppModels
{
    public static class PageToEditList
    {
        public static List<PageDescription> PagesList { get; set; } = new List<PageDescription>()
        {
            new PageDescription()
            {
                Name = "O nas",
                Page = Page.HomeAbout
            }
        };
    }
}