namespace QL_BangKiem_KhaoSat.Models
{
    public class DanhSachBangKiem
    {
        public string TenBangKiem { get; set; }
        public string MoTaNgan { get; set; } // Ví dụ: "Bảng kiểm dành cho Điều dưỡng"
        public string Url { get; set; } // URL để điều hướng đến form của bảng kiểm này
        public string ImageUrl { get; set; } // Đường dẫn đến ảnh đại diện (nếu có)
    }
}
