using System.ComponentModel.DataAnnotations;

namespace AssignmentC4.Areas.Admin.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(200)]
        public string Subject { get; set; }

        [Required]
        [StringLength(2000)]
        public string Message { get; set; }

        public string Status { get; set; } = "New"; // New, Read, Replied

        public string AdminReply { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ReadDate { get; set; }

        public DateTime? RepliedDate { get; set; }
    }
}