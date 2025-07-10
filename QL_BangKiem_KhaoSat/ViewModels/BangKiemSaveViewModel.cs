namespace QL_BangKiem_KhaoSat.ViewModels
{
    public class BangKiemSaveViewModel
    {
        public string TenForm { get; set; }
        public string Title { get; set; }
        public DateTime NgayGiamSat { get; set; }
        public string Khoa { get; set; }
        public string DieuDuongThucHien { get; set; }
        public string NguoiGiamSat { get; set; }
        public string GhiChu { get; set; }
        public string Note { get; set; }
        public string NhomThaoTacJson { get; set; }
        public List<BangKiemStepResultViewModel> KetQua { get; set; }
    }

    public class BangKiemStepResultViewModel
    {
        public int StepIndex { get; set; }
        public string StepName { get; set; }
        public string KetQuaLoai { get; set; }
        public float? Diem { get; set; }
        public float? KetQuaNhom1 { get; set; }
        public float? KetQuaNhom2 { get; set; }
        public List<string> KetQuaNhom1List { get; set; }
        public List<string> KetQuaNhom2List { get; set; }
        public string LoaiKetQua { get; set; }
        public List<BangKiemSubStepResultViewModel> SubSteps { get; set; }
    }

    public class BangKiemSubStepResultViewModel
    {
        public string SubStepName { get; set; }
        public float? KetQuaNhom1 { get; set; }
        public float? KetQuaNhom2 { get; set; }
        public float? Diem { get; set; }
    }

}
