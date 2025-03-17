using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class LOAINHANVIEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idLoaiNhanVien")]
        public int IdLoaiNhanVien { get; set; }

        [Required]
        [StringLength(50)]
        [Column("tenLoaiNhanVien")]
        public string TenLoaiNhanVien { get; set; }

        public ICollection<NHANVIEN>? NhanViens { get; set; }
    }
}
