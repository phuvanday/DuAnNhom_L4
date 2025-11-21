using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Models
{
    [Table("HinhAnh")]
    public class Image   // đổi tên từ Anh → Image
    {
        [Key]
        public int MaHA { get; set; }

        public int MaBT { get; set; }  // FK

        [ForeignKey("MaBT")]
        public Variant Variant { get; set; }

        public string HinhAnh { get; set; }
    }
}
