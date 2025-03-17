using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class TACGIA
    {
        [Key]
        [StringLength(7)]
        [Column("idTacGia")]
        public string IdTacGia { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tenTacGia")]
        public string TenTacGia { get; set; }

        public ICollection<SANPHAM_TACGIA> SanPhamTacGias { get; set; }
    }
}
