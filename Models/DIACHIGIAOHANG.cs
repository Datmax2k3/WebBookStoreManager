using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class DIACHIGIAOHANG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idDiaChi")]
        public int IdDiaChi { get; set; }

        [StringLength(100)]
        [Column("hoVaTen")]
        public string HoVaTen { get; set; }

        [StringLength(225)]
        [Column("diaChiGiaoHang")]
        public string DiaChiGiaoHang { get; set; }

        [StringLength(11)]
        [Column("sdtGiaoHang")]
        public string SdtGiaoHang { get; set; }

        [Required]
        [Column("idNguoiDung")]
        public int IdNguoiDung { get; set; }

        [ForeignKey("IdNguoiDung")]
        public NGUOIDUNG NguoiDung { get; set; }
    }
}
