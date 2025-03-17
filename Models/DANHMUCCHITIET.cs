using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class DANHMUCCHITIET
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idDanhMucCT")]
        public int IdDanhMucCT { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tenDanhMucCT")]
        public string TenDanhMucCT { get; set; }

        [Column("idDanhMuc")]
        public int? IdDanhMuc { get; set; }

        [ForeignKey("IdDanhMuc")]
        public DANHMUC DanhMuc { get; set; }

        public ICollection<SANPHAM> SanPhams { get; set; }
    }
}
