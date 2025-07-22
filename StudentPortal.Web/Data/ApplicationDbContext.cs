using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models; 

namespace StudentPortal.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor ini penting agar kita bisa mengkonfigurasi koneksi database dari luar
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Mahasiswa> Mahasiswas { get; set; }
    }
}
