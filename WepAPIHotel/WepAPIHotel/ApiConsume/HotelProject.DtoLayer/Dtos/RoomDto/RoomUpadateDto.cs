using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpadateDto
    {

        public int RoomId { get; set; }

        [Required(ErrorMessage = "lütfen oda numarasını yazınız.")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "lütfen oda görselini giriniz.")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisini giriniz")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen odabaşlıgı bilgisini giriniz")]
        [StringLength(100,ErrorMessage ="lütfen en fazla 100 karakter girişi yapınız")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı bilgisini giriniz")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısı bilgisini giriniz")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
