using AssignmentC4.Areas.Admin.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Areas.User.Models
{
    [Table("BienThe")]
    public class BienThe
    {
        [Key]
        public int MaBT { get; set; }

        public int MaSP { get; set; }

        public string KichCo { get; set; }
        public string MauSac { get; set; }

        // Navigation
        public virtual Product Product { get; set; }
        public virtual ICollection<HinhAnh> HinhAnh { get; set; }
    }
}
