using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCourse1920_Nhom46.Models
{
    public class SinhVien
    {
        [Key]
        [Display(Name ="Mã Sinh Viên")]
        public int MaSV { get; set; }
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Điện Thoại")]
        public string DienThoai { get; set; }


        public int MaLHP { get; set; }
        [ForeignKey("MaLHP")]
        public LopHocPhan LopHocPhan { get; set; }

        public int MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public Khoa Khoa { get; set; }

        public ICollection<KetQuaHocTap> KetQuaHocTaps { get; set; }
    }
}
