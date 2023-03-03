using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace DomainLayer.Domains
{
    [Table("Persons")]
    public class Person : BaseEntity
    {
        [Required, Column("Name")]

        public string Name { get; set; }
        [Required, Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Required, Column("Gender")]
        public int Gender { get; set; }
        [Required, Column("MaritalStatus")]
        public int MaritalStatus { get; set; }
        [Required, Column("CreationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public List<PersonInfosInDifferentLanguages>? PersonInfoLanguages { get; set; } = new List<PersonInfosInDifferentLanguages>();
    }
}
