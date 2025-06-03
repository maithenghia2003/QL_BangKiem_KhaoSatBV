namespace QL_BangKiem_KhaoSat.Models
{
    public class BangKiemAnToanPhauThuat
    {
        // Thông tin chung
        public string HoTenNguoiBenh { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string MaNguoiBenh { get; set; }
        public string ChuanDoanTruocMo { get; set; }
        public string PhongMo { get; set; }
        public DateTime NgayPhauThuat { get; set; }

        // Các mục kiểm tra theo giai đoạn
        public List<MucKiemTra> TruocGayMeGayTe { get; set; }
        public List<MucKiemTra> TruocKhiRachDa { get; set; }
        public List<MucKiemTra> TruocKhiKetThucMo { get; set; }

        public BangKiemAnToanPhauThuat()
        {
            TruocGayMeGayTe = new List<MucKiemTra>();
            TruocKhiRachDa = new List<MucKiemTra>();
            TruocKhiKetThucMo = new List<MucKiemTra>();
        }
    }
}
