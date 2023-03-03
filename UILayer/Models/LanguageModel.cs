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
        public int? Id { get; set; }
        [DisplayName("Language Name")]
        public String? Name { get; set; }
        [DisplayName("All Languages")]
        public List<SelectListItem>? AllLanguages { get; set; }
    }
}
