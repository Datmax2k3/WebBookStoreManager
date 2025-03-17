using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBookStoreManage.Models
{
    public class VAITRO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idVaiTro")]
        public int IdVaiTro { get; set; }

        [Required]
        [StringLength(100)]
        [Column("tenVaiTro")]
        public string TenVaiTro { get; set; }

        public ICollection<TAIKHOAN> TaiKhoans { get; set; }
    }
}
