using SerimCase.Entities.Abstract;
using SerimCase.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerimCase.Entities.Concrete
{
    [Table("Customers")]
    public class Customer : BaseEntity,IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
    }
}
