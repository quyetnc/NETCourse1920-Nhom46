using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCourse1920_Nhom46.Models
{
    public class QuanLyDbContext : DbContext
    {
        public QuanLyDbContext(DbContextOptions op) : base (op)
        {

        }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<LopHocPhan> LopHocPhans { get; set; }
        public DbSet<KetQuaHocTap> KetQuaHocTaps { get; set; }
    }
}
