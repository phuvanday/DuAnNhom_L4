using System.ComponentModel.DataAnnotations;

namespace AssignmentC4.Areas.User.Models
{
    public class SanPham
    {
        [Key]
        public int MaSP {  get; set; }
        public int MaDM { get; set; }
        public string? TenSanPham {  get; set; }
        public string? HinhAnhDaiDien {  get; set; }
        public decimal GiaCoBan {  get; set; }
        public string? LoaiGiay {  get; set; }
        public int SoLuong {  get; set; }
        public string? ThuongHieu {  get; set; }
        public string? MoTa {  get; set; }
        public ICollection<BienThe> BienThes { get; set; }
    }
}
