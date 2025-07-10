namespace QL_BangKiem_KhaoSat.Models
{
    public class LichSuDuyetEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string HanhDong { get; set; } // "Duyệt" hoặc "Từ chối"
        public DateTime ThoiGian { get; set; }
        public string? GhiChu { get; set; }
        public UserEntity User { get; set; }
    }
}
