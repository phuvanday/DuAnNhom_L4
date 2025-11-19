using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentC4.Areas.User.Models
{
    public class BienThe
    {
        [Key]
        public int MaBT {  get; set; }
        public int MaSP {  get; set; }
        public string? MauSac {  get; set; }
        public string? KichCo {  get; set; }
        public int SoLuong {  get; set; }
        public decimal Gia {  get; set; }
        [ForeignKey("MaSP")]
        public SanPham SanPham { get; set; }
        public ICollection<HinhAnh> HinhAnh { get; set; }
    }
}
