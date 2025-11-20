using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Areas.User.Models
{
    [Table("BienThe")]
    public class BienThe
    {
        [Key]
        public int MaBT { get; set; }
        public int MaSP { get; set; }
        public string? MauSac { get; set; }
        public string? KichCo { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        [ForeignKey("MaSP")]
        public virtual Product Product { get; set; }
        public virtual ICollection<HinhAnh> HinhAnh { get; set; }
    }
}
