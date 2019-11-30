using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCourse1920_Nhom46.Models
{
    public class LopHocPhan
    {
        [Key]
        [Display(Name = "Mã Lớp HP")]
        public int MaLHP { get; set; }
        [Display(Name = "Năm Học")]
        public string NamHoc { get; set; }
        [Display(Name = "Học Kỳ")]
        public string HocKy { get; set; }

        public int MaMon { get; set; }
        [ForeignKey("MaMon")]
        public MonHoc MonHoc { get; set; }

        [Display(Name = "Điểm Giữa Kỳ")]
        public double DiemGK { get; set; }
        [Display(Name = "Điểm Cuối Kỳ")]
        public double DiemCuoiKy { get; set; }

        public ICollection<SinhVien> SinhViens { get; set; }

        public ICollection<KetQuaHocTap> KetQuaHocTaps { get; set; }

    }
}
