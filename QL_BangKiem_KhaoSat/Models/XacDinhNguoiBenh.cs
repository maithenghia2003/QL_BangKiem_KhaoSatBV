namespace QL_BangKiem_KhaoSat.Models
{
    public class XacDinhNguoiBenh
    {
        // Thời điểm đánh giá
        public bool ThoiDiemDanhGia_TiepNhan { get; set; }
        public bool ThoiDiemDanhGia_TuVan { get; set; }
        public bool ThoiDiemDanhGia_ThanhToan { get; set; }
        public bool ThoiDiemDanhGia_ThuPhiCLS { get; set; }
        public bool ThoiDiemDanhGia_CapPhatThuoc { get; set; }
        public bool ThoiDiemDanhGia_CapPhatToaThuoc { get; set; }
        public bool ThoiDiemDanhGia_CapPhieuHen { get; set; }
        public bool ThoiDiemDanhGia_ThucHienCLS { get; set; }
        public bool ThoiDiemDanhGia_CapPhatChiDinhCLS { get; set; }
        public bool ThoiDiemDanhGia_TraKetQuaCLS { get; set; }
        public bool ThoiDiemDanhGia_ThucHienKyThuat { get; set; }
        public bool ThoiDiemDanhGia_ThucHienThuThuat { get; set; }
        public bool ThoiDiemDanhGia_ThucHienPhauThuat { get; set; }
        public bool ThoiDiemDanhGia_ThucHienCLSKhac { get; set; }
        public bool ThoiDiemDanhGia_NhapVien { get; set; }
        public bool ThoiDiemDanhGia_ChuyenKhoa { get; set; }
        public bool ThoiDiemDanhGia_ChuyenVien { get; set; }
        public bool ThoiDiemDanhGia_XuatVien { get; set; }
        // ... Thêm các thuộc tính boolean khác cho thời điểm đánh giá

        public List<YeuToXacDinh> CacYeuTo { get; set; }

        public string TenNVYT1 { get; set; }
        public string TenNVYT2 { get; set; }

        // Kết luận bảng kiểm
        public string KetLuanNVYT1 { get; set; }
        public string KetLuanNVYT2 { get; set; }
    }
}
