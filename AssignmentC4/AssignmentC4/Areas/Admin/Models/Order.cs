using AssignmentC4.Areas.User.Models;
using System.ComponentModel.DataAnnotations;

namespace AssignmentC4.Areas.Admin.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderCode { get; set; } // Mã đơn hàng: ORD-20250116-001

        public int? UserId { get; set; } // Null nếu khách vãng lai

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        public string Note { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal ShippingFee { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal FinalAmount { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";
        // Pending, Confirmed, Shipping, Delivered, Cancelled

        [Required]
        public string PaymentMethod { get; set; }
        // COD, Banking, Momo

        public bool IsPaid { get; set; } = false;

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public DateTime? ShippingDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        // Navigation property
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}