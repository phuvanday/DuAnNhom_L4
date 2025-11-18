using System.ComponentModel.DataAnnotations;

namespace AssignmentC4.Areas.Admin.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã sản phẩm")]
        [StringLength(50)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn hãng giày")]
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "Giảm giá từ 0-100%")]
        public int Discount { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0")]
        public int Stock { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public string Category { get; set; } // Nam, Nữ, Trẻ em

        public string Size { get; set; } // 38,39,40,41,42

        public string Color { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsFeatured { get; set; } // Sản phẩm nổi bật

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
    }
}
