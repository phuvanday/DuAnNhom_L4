using AssignmentC4.Areas.User.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Areas.Admin.Models
{
    [Table("SanPham")]
    public class Product
    {
        [Key]
        public int MaSP { get; set; }

        [Display(Name = "Danh mục")]
        public int? MaDM { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        [StringLength(400)]
        public string TenSanPham { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Display(Name = "Giá cơ bản")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaCoBan { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Display(Name = "Hình ảnh đại diện")]
        [StringLength(510)]
        public string? HinhAnhDaiDien { get; set; }

        [Display(Name = "Loại giày")]
        [StringLength(100)]
        public string LoaiGiay { get; set; }

        [Required(ErrorMessage = "Thương hiệu không được để trống")]
        [Display(Name = "Thương hiệu")]
        [StringLength(200)]
        public string ThuongHieu { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        // Navigation property
        public virtual ICollection<BienThe> BienThes { get; set; }

        // Helper properties để hiển thị trong view
        [NotMapped]
        public string ImageUrl => string.IsNullOrEmpty(HinhAnhDaiDien)
            ? "/images/no-image.jpg"
            : $"/images/{HinhAnhDaiDien}";

        [NotMapped] public string Name => TenSanPham;
        [NotMapped] public decimal Price => GiaCoBan;
        [NotMapped] public int Stock => SoLuong;
        [NotMapped] public string BrandName => ThuongHieu;
        [NotMapped] public bool IsActive => SoLuong > 0;
        [NotMapped] public string Code => $"SP{MaSP:D5}";
    }
}