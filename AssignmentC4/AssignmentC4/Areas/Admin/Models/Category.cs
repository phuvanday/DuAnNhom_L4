using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Areas.Admin.Models // hoặc namespace phù hợp
{
    [Table("DanhMuc")] // Hoặc tên table thực tế trong DB
    public class DanhMuc
    {
        [Key]
        public int MaDM { get; set; }

        [Required]
        [StringLength(200)]
        public string TenDanhMuc { get; set; }

        // Các thuộc tính khác nếu có...
    }
}