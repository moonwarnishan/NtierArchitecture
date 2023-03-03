using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace UILayer.Models
{
    public class LanguageModel
    {
        public LanguageModel()
        {
            AllLanguages = new List<SelectListItem>();
        }
        public int? LanguageId { get; set; }
        [DisplayName("Language Name")]
        public String? LanguageName { get; set; }
        [DisplayName("All Languages")]
        public List<SelectListItem>? AllLanguages { get; set; }
    }
}
