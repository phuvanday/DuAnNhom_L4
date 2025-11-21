using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Models
{
    [Table("ChiTietHoaDon")]
    public class OrderDetail
    {
        [Key]
        public int MaCTHD { get; set; }

        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }

        [ForeignKey("MaHD")]
        public Order Order { get; set; }

        [ForeignKey("MaSP")]
        public Product Product { get; set; }
    }
}
