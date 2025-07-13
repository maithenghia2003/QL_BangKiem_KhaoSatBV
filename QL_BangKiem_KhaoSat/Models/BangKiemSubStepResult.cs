namespace QL_BangKiem_KhaoSat.Models
{
    public class BangKiemSubStepResult
    {
        public int Id { get; set; }
        public int StepResultId { get; set; }
        public BangKiemStepResult BangKiemStepResult { get; set; }
        public string SubStepName { get; set; }
        public float? KetQuaNhom1 { get; set; }
        public float? KetQuaNhom2 { get; set; }
        public float? Diem { get; set; }
    }
}
