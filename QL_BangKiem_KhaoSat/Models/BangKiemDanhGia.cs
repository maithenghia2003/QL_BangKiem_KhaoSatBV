namespace QL_BangKiem_KhaoSat.Models
{
    public class BangKiemDanhGia
    {
        public int Id { get; set; }
        public int BangKiemId { get; set; }
        public string NguoiDanhGia { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGian { get; set; }
        public string Avatar { get; set; } // Tuỳ chọn cho giao diện đẹp

        public BangKiemEntity BangKiem { get; set; }
    }
}
