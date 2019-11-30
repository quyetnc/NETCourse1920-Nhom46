using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCourse1920_Nhom46.Models
{
    public class MonHoc
    {
        [Key]
        [Display(Name = "Mã Môn")]
        public int MaMon { get; set; }
        [Display(Name = "Tên Môn")]
        public string TenMon { get; set; }
        [Display(Name = "Số Tín Chỉ")]
        public int SoTinChi { get; set; }

        public ICollection<LopHocPhan> LopHocPhans { get; set; }

        public ICollection<KetQuaHocTap> KetQuaHocTaps { get; set; }
    }
}
