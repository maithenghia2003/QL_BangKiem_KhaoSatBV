namespace QL_BangKiem_KhaoSat.Models
{
    public class BangKiemEntity
    {
        public int Id { get; set; }
        public string TenForm { get; set; }
        public string Title { get; set; }
        public DateTime NgayGiamSat { get; set; }
        public string Khoa { get; set; }
        public string DieuDuongThucHien { get; set; }
        public string NguoiGiamSat { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public string Note { get; set; }
        public string NhomThaoTacJson { get; set; }
        public ICollection<BangKiemStepResult> KetQua { get; set; }
    }

}
