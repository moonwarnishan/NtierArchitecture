using DomainLayer.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Models
{
    internal class PersonInfoIndifferentLanguagesServiceModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int MaritalStatus { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public Person Person { get; set; }
        [Required]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
