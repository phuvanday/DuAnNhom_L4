using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Models
{
    [Table("TaiKhoan")]
    public class Account
    {
        [Key]
        public int MaTK { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public string Quyen { get; set; } // Admin/User
        public int MaND { get; set; }

        [ForeignKey("MaND")]
        public User User { get; set; }
    }
}
