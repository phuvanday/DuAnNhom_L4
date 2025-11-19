using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Areas.User.Models
{
    public class HinhAnh
    {
        [Key]
        public int MaHA {  get; set; }
        [ForeignKey("MaBT")]
        public int MaBT {  get; set; }
        [Column("HinhAnh")]
        public string? HinhAnhUrl {  get; set; }
        public BienThe BienThe { get; set; }
    }
}
