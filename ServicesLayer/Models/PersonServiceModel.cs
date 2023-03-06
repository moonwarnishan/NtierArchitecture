using DomainLayer.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Models
{
    public class PersonServiceModel
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

        public DateTime CreationDate { get; set; } 

        public List<PersonInfosInDifferentLanguages>? PersonInfoLanguages { get; set; } = new List<PersonInfosInDifferentLanguages>();
    }
}
