using System.ComponentModel.DataAnnotations;

namespace AssignmentC4.Areas.Admin.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên hãng")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}