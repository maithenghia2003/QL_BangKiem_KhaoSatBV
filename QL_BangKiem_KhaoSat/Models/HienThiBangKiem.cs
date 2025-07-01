namespace QL_BangKiem_KhaoSat.Models
{
    public class HienThiBangKiem
    {
        public List<DanhSachBangKiem> DSBangKiem { get; set; }

        public HienThiBangKiem()
        {
            DSBangKiem = new List<DanhSachBangKiem>();
        }
    }
}
