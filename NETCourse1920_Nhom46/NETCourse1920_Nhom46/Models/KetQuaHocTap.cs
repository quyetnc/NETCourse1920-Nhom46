using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCourse1920_Nhom46.Models
{
    public class KetQuaHocTap
    {
        [Key]
        [Display(Name ="Mã KQHT")]
        public int MaKQHT { get; set; }


        public int MaSV { get; set; }
        [ForeignKey("MaSV")]
        public SinhVien SinhVien { get; set; }

        public int MaLHP { get; set; }
        [ForeignKey("MaLHP")]
        public LopHocPhan LopHocPhan { get; set; }



    }
}
