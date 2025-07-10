namespace QL_BangKiem_KhaoSat.Models
{
    public class BangKiemStepResult
    {
        public int Id { get; set; }
        public int BangKiemEntityId { get; set; }
        public BangKiemEntity BangKiem { get; set; }
        public int StepIndex { get; set; }
        public string StepName { get; set; }
        public string KetQuaLoai { get; set; }
        public float? Diem { get; set; }
        public float? KetQuaNhom1 { get; set; }
        public float? KetQuaNhom2 { get; set; }
        public string LoaiKetQua { get; set; }
        public List<BangKiemSubStepResult> SubSteps { get; set; } = new List<BangKiemSubStepResult>();
    }
}
