using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Domains
{
    public class Person : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int MaritalStatus { get; set; }
        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public List<PersonInfosInDifferentLanguages>? PersonInfoLanguages { get; set; }
    }
}
