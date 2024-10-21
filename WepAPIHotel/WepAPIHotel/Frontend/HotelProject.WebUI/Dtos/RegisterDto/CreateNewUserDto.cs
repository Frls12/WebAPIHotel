using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "ad alanı gereklidir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Kullanıcı ad alanı gereklidir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "mail alanı gereklidir")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "şifre alanı gereklidir")]
        public string Password { get; set; }

        [Required(ErrorMessage = "şifre tekrar alanı gereklidir")]
        [Compare("Password",ErrorMessage ="şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

    }
}
