using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class SANPHAM_TACGIA
    {
        [Key, Column("idSanPham", Order = 0)]
        [StringLength(7)]
        public string IdSanPham { get; set; }

        [Key, Column("idTacGia", Order = 1)]
        [StringLength(7)]
        public string IdTacGia { get; set; }

        public SANPHAM SanPham { get; set; }
        public TACGIA TacGia { get; set; }
    }
}
