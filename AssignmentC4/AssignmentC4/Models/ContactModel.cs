using System.ComponentModel.DataAnnotations;

namespace AssignmentC4.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string TieuDe { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string NoiDung { get; set; }
    }
}
