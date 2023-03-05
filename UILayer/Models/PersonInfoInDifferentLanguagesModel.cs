using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DomainLayer.Domains;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UILayer.Models
{
    public class PersonInfoInDifferentLanguagesModel
    {
        public PersonInfoInDifferentLanguagesModel()
        {
            AllPersons = new List<SelectListItem>();
            AllLanguages = new List<SelectListItem>();
            AllGenders = new List<SelectListItem>();
            AllMaterialStatus = new List<SelectListItem>();
        }
        public int? Id { get; set; }
        [DisplayName("Name")]
        public string? Name { get; set; } 
        [Required, DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int? Gender { get; set; }
        [Required, DisplayName("Marital Status")]
        public int? MaritalStatus { get; set; }
        [Required, DisplayName("Marital Status")]
        public string? MaritalStatusInfo { get; set; }
        [Required, DisplayName("Gender")]
        public string? GenderInfo { get; set; }

        public int? PersonId { get; set; }
        public Person? Person { get; set; }
        public int? LanguageId { get; set; }
        public Language? Language { get; set; }
        [DisplayName("All Persons")]
        public List<SelectListItem>? AllPersons { get; set; }
        [DisplayName("All Languages")]
        public List<SelectListItem>? AllLanguages { get; set; }
        public List<SelectListItem>? AllGenders { get; set; }
        public List<SelectListItem>? AllMaterialStatus { get; set; }

    }
}
