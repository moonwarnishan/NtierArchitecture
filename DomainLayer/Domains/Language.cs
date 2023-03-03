using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Domains
{
    public class Language : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<PersonInfosInDifferentLanguages>? PersonInfoDifferentLanguage { get; set; }
    }
}
