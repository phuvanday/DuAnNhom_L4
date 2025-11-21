using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Models
{
    [Table("HoaDon")]
    public class Order
    {
        [Key]
        public int MaHD { get; set; }

        public DateTime NgayLap { get; set; }

        public int MaND { get; set; }

        [ForeignKey("MaND")]
        public User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
