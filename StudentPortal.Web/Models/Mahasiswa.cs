using  System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class Mahasiswa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "NIM wajib diisi.")]
        [Display(Name = "NIM")]
        public string? NIM { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [StringLength(100, ErrorMessage = "Nama tidak boleh lebih dari 100 karakter.")]
        [Display(Name = "Nama Lengkap")]
        public string? Nama { get; set; }

        [Required(ErrorMessage = "Jurusan wajib diisi.")]
        public string? Jurusan { get; set; }

        [Required(ErrorMessage = "Tanggal Lahir wajib diisi.")]
        [DataType(DataType.Date)] // Memberitahu MVC untuk menampilkan UI kalender
        [Display(Name = "Tanggal Lahir")]
        public DateTime TanggalLahir { get; set; }

    }
}
