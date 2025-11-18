using System.ComponentModel.DataAnnotations;

namespace AssignmentC4.Areas.Admin.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        [StringLength(300)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập slug")]
        [StringLength(300)]
        public string Slug { get; set; } // URL-friendly title

        [Required(ErrorMessage = "Vui lòng nhập mô tả ngắn")]
        [StringLength(500)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public string Category { get; set; }
        // Tin tức, Khuyến mãi, Hướng dẫn, Review

        public int ViewCount { get; set; } = 0;

        public bool IsPublished { get; set; } = true;

        public bool IsFeatured { get; set; } = false;

        public string Author { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? PublishedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}