namespace QL_BangKiem_KhaoSat.Models
{
    public class StepEntity
    {
        public int Id { get; set; }
        public string FormKey { get; set; } // VD: "Form1"
        public int StepIndex { get; set; }
        public string StepName { get; set; }
        public bool IsActive { get; set; }
    }
}
