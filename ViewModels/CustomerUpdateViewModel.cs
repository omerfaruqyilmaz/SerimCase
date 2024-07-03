using SerimCase.Entities.Enum;

namespace SerimCase.ViewModels
{
    public class CustomerUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public Gender Gender { get; set; }
    }
}
