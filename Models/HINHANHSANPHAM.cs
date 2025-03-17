using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class HINHANHSANPHAM
    {
        [Key]
        [StringLength(7)]
        [Column("idHinhAnh")]
        public string IdHinhAnh { get; set; }

        [Required]
        [StringLength(100)]
        [Column("urlAnh")]
        public string UrlAnh { get; set; }

        [Required]
        [StringLength(7)]
        [Column("idSanPham")]
        public string IdSanPham { get; set; }

        [ForeignKey("IdSanPham")]
        public SANPHAM SanPham { get; set; }
    }
}
