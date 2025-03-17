using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class DANHMUC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idDanhMuc")]
        public int IdDanhMuc { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tenDanhMuc")]
        public string TenDanhMuc { get; set; }

        [Required]
        [Column("thuTu")]
        public int ThuTu { get; set; }

        public ICollection<DANHMUCCHITIET> DanhMucChiTiets { get; set; }
    }
}
