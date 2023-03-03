using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Domains
{
    public class PersonInfosInDifferentLanguages : BaseEntity
    {
        public string Name { get; set; } 
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int MaritalStatus { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
