using DomainLayer.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Models
{
    public class LanguageServiceModel
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<PersonInfosInDifferentLanguages> PersonInfoDifferentLanguage { get; set; } = new List<PersonInfosInDifferentLanguages>();
    }
}
