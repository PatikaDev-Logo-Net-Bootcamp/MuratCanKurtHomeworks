using System.ComponentModel.DataAnnotations;

namespace Homework4.Domain.Entities
{
    public class Company : BaseEntity
    {
        [Required(ErrorMessage = "Name of Company is a required field.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
    }
}
