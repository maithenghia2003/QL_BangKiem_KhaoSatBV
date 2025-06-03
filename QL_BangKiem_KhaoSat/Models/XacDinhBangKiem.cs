namespace QL_BangKiem_KhaoSat.Models
{
    public class XacDinhBangKiem
    {
        public List<YeuToXacDinh> CacYeuTo { get; set; }

        // Tên NVYT thực hiện
        public string TenNVYT1 { get; set; }
        public string TenNVYT2 { get; set; }

        // Kết luận Đúng người bệnh
        public string KetLuanDungNguoiBenhNVYT1 { get; set; }
        public string KetLuanDungNguoiBenhNVYT2 { get; set; }

        public XacDinhBangKiem()
        {
            CacYeuTo = new List<YeuToXacDinh>();
            TenNVYT1 = string.Empty;
            TenNVYT2 = string.Empty;
            KetLuanDungNguoiBenhNVYT1 = string.Empty;
            KetLuanDungNguoiBenhNVYT2 = string.Empty;
        }
    }
}
