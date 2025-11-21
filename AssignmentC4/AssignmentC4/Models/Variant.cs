using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Models
{
    [Table("BienThe")]
    public class Variant
    {
        [Key]
        public int MaBT { get; set; }

        public int MaSP { get; set; }  // FK

        [ForeignKey("MaSP")]
        public Product Product { get; set; }

        public string KichCo { get; set; }

        public string MauSac { get; set; }

        public decimal Gia { get; set; }

        public int SoLuong { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
