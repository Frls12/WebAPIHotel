using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığını giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet başlıgı en fazla 100 karakter olabilir")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet Açıklaması giriniz")]
        [StringLength(500, ErrorMessage = "Hizmet açıklaması en fazla 500 karakter olabilir")]
        public string description { get; set; }
    }
}
