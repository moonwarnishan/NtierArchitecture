using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UILayer.Models
{
    public class PersonModel
    {
        public PersonModel()
        {
            MaritalStatuses = new List<SelectListItem>();
            Genders = new List<SelectListItem>();
        }
        public int? PersonId { get; set; }
        [Required, Display(Name = "Name")]
        public string? PersonName { get; set; }
        [Required, DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int? Gender { get; set; }
        [DisplayName("Gender")]
        public string? GenderInfo { get; set; }
        
        public int? MaritalStatus { get; set; }
        [Required, DisplayName("Marital Status")]
        public string? MaritalStatusInfo { get; set; }
        [Required]
        [DisplayName("Creation Date")]
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        [DisplayName("Marital Statuses")]
        public IList<SelectListItem>? MaritalStatuses { get; set; }
        [DisplayName("Genders")]
        public IList<SelectListItem>? Genders { get; set; }
    }
}
