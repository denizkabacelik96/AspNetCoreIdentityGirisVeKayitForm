using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityOrnek.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name="Kullanıcı Adı:")]
        [Required(ErrorMessage="Kullanıcı adı  boş  geçilemez")]
        public string UserName { get; set; }
        [Display(Name = "Şifre:")]
        [Required(ErrorMessage = "Parola  boş  geçilemez")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar:")]
        [Compare("Password",ErrorMessage ="Paralolar eşleşmiyor")]
        public string ConfirmPassword { get; set; }
        [Display(Name = " Ad:")]
        [Required(ErrorMessage = " Ad  boş  geçilemez")]
        public string  Name { get; set; }
        [Display(Name = "Soyad:")]
        [Required(ErrorMessage = "Soyad adı  boş  geçilemez")]
        public string SurName { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email adı  boş  geçilemez")]
        public string Email { get; set; }
    }
}
