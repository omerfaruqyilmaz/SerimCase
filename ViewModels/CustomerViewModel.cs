using SerimCase.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace SerimCase.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsStatus { get; set; }
    }
}
