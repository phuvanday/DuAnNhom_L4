using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Models
{
    [Table("DanhMuc")]
    public class Category
    {
        [Key]
        public int MaDM { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDanhMuc { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
