using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Models
{
    [Table("SanPham")]
    public class Product
    {
        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(150)]
        public string TenSanPham { get; set; }

        public decimal GiaCoBan { get; set; }

        public string ThuongHieu { get; set; }

        public string LoaiGiay { get; set; }

        public int MaDM { get; set; }  // FK

        [ForeignKey("MaDM")]
        public Category Category { get; set; }

        public string HinhAnhDaiDien { get; set; }

        [NotMapped]
        public IFormFile HinhAnhFile { get; set; }

        public string MoTa { get; set; }

        public int SoLuong
        {
            get
            {
                return Variants?.Sum(v => v.SoLuong) ?? 0;
            }
        }

        public ICollection<Variant> Variants { get; set; }
    }
}
