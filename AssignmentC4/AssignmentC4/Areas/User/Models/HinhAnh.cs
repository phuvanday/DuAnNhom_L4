using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Areas.User.Models
{
    [Table("HinhAnh")]
    public class HinhAnh
    {
        [Key]
        public int MaHA { get; set; }
        [ForeignKey("MaBT")]
        public int MaBT { get; set; } // foreign key
        [Column("HinhAnh")]
        public string Url { get; set; }

        // Navigation
        public virtual BienThe BienThe { get; set; }
    }
}
