using Microsoft.AspNetCore.Mvc;
using SerimCase.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace SerimCase.ViewModels
{
    public class CustomerCreateViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı boş olamaz")]
        [StringLength(50, ErrorMessage = "Ad alanı 50 karakterden uzun olamaz")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş olamaz")]
        [StringLength(50, ErrorMessage = "Soyad alanı 50 karakterden uzun olamaz")]
        public string SurName { get; set; }

        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Telefon Numarası alanı boş olamaz")]
        [StringLength(15, ErrorMessage = "Telefon Numarası alanı 15 karakterden uzun olamaz")]
        public string PhoneNumber { get; set; }

        [Remote(action: "HasCustomerEmail",controller:"Customer")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Email adresi uygun formatta değil")]
        [Required(ErrorMessage = "Email alanı boş olamaz")]
        [StringLength(100, ErrorMessage = "Email alanı 100 karakterden uzun olamaz")]
        public string Email { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi alanı boş olamaz")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı boş olamaz")]
        public Gender Gender { get; set; }
    }
}
