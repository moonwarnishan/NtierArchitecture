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
    [Table("PersonsInfoInDifferentLanguages")]
    public class PersonInfosInDifferentLanguages : BaseEntity
    {
        [Required, Column("Name")]
        public string Name { get; set; } 
        [Required, Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Required, Column("Gender")]
        public int Gender { get; set; }
        [Required, Column("MaritalStatus")]
        public int MaritalStatus { get; set; }
        [Column("PersonId")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [Column("LanguageId")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
