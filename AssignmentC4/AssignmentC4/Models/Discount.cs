using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Models
{
    [Table("GiamGia")]
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; } // MaGG

        public int Value { get; set; } // GiaTri

        [StringLength(50)]
        public string Code { get; set; } // MaCode

        public DateTime CreatedAt { get; set; } // NgayTao
        public DateTime StartDate { get; set; } // NgayBatDau
        public DateTime EndDate { get; set; } // NgayKetThuc

        [StringLength(50)]
        public string Type { get; set; } // LoaiGiamGia

        [StringLength(50)]
        public string Scope { get; set; } // PhamVi

        [StringLength(50)]
        public string Status { get; set; } // TrangThai

        public int Quantity { get; set; } // SoLuong
    }
}
