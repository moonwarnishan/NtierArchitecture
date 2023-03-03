using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Domains
{
    [Table("Languages")]
    public class Language : BaseEntity
    {
        [Required,Column("Name")]
        public string Name { get; set; }
        public List<PersonInfosInDifferentLanguages> PersonInfoDifferentLanguage { get; set; } = new List<PersonInfosInDifferentLanguages>();
    }
}
