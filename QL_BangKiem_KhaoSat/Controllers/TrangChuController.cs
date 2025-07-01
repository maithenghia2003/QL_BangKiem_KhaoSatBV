using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class TrangChuController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HienThiBangKiem
            {
                DSBangKiem = new List<DanhSachBangKiem>
            {
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM THỰC HIỆN KỸ THUẬT TIÊM TĨNH MẠCH",
                    MoTaNgan = "Tiêm truyền an toàn",
                    Url = "/TiemTinhMach", // URL đến Controller/Action của bảng kiểm này
                    ImageUrl = "https://medlatec.vn/media/2060/content/20230317_tiem-tinh-mach-1.jpg" // Đường dẫn ảnh, bạn cần tạo ảnh này
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM THỰC HIỆN KỸ THUẬT TIÊM DƯỚI BẮP",
                    MoTaNgan = "Tiêm truyền an toàn",
                    Url = "/TiemDuoiBap",
                    ImageUrl = "https://www.vinmec.com/static/uploads/20200305_095047_517240_cac_tai_bien_co_xay_max_1800x1800_jpg_534f166906.jpg"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM THỰC HIỆN KỸ THUẬT TIÊM DƯỚI DA",
                    MoTaNgan = "Tiêm truyền an toàn",
                    Url = "/TiemDuoiDa",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZv1QP9_YoEZnXtGTmJbCeXLRShl0hbqcxrQ&s"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM THỰC HIỆN QUY TRÌNH KỸ THUẬT TRUYỀN MÁU",
                    MoTaNgan = "Tiêm truyền an toàn",
                    Url = "/TruyenMau",
                    ImageUrl = "https://phunuvietnam.mediacdn.vn/thumb_w/700/179072216278405120/2020/6/26/truyen-thuoc-15931320760321330308318-18-0-518-800-crop-15931320842371092339658.jpg"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM THỰC HIỆN KỸ THUẬT TRUYỀN DỊCH",
                    MoTaNgan = "Tiêm truyền an toàn",
                    Url = "/TruyenDich",
                    ImageUrl = "https://cdn.nhathuoclongchau.com.vn/unsafe/800x0/https://cms-prod.s3-sgn09.fptcloud.com/ky_thuat_truyen_dich_tinh_mach_phan_loai_quy_trinh_va_nguyen_tac_thuc_hien_0c1d2d5bd0.png"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM TIÊM TRUYỀN HÓA CHẤT TĨNH MẠCH NGOẠI VI",
                    MoTaNgan = "Tiêm truyền an toàn",
                    Url = "/TruyenTinhMachNgoaiVi",
                    ImageUrl = "https://cdn.nhathuoclongchau.com.vn/unsafe/800x0/https://cms-prod.s3-sgn09.fptcloud.com/ky_thuat_dat_kim_luon_tinh_mach_ngoai_vi_4_b3e011057b.jpg"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM KỸ THUẬT THAY BĂNG VẾT THƯƠNG NHIỄM",
                    MoTaNgan = "Kiểm soát nhiễm khuẩn",
                    Url = "/ThayBangVetThuongNhiem",
                    ImageUrl = "https://truongcaodangduocsaigon.edu.vn/Uploads/images/124.png"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM KỸ THUẬT THAY BĂNG VẾT THƯƠNG VÔ KHUẨN",
                    MoTaNgan = "Kiểm soát nhiễm khuẩn",
                    Url = "/ThayBangVetThuongVoKhuan",
                    ImageUrl = "https://cdn.nhathuoclongchau.com.vn/unsafe/800x0/filters:quality(95)/https://cms-prod.s3-sgn09.fptcloud.com/cach_thay_bang_vet_thuong_4_c79d91b646.jpg"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM KỸ THUẬT THAY BĂNG VẾT THƯƠNG CÓ ỐNG DẪN LƯU",
                    MoTaNgan = "Kiểm soát nhiễm khuẩn",
                    Url = "/ThayBangOngDan",
                    ImageUrl = "https://file.hstatic.net/200000320179/article/screenshot_2024-06-05_at_16.28.11_04d32764bf0742b6863b78f0a68b5dab_1024x1024.png"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM KỸ THUẬT THAY BĂNG VẾT THƯƠNG CÓ ỐNG DẪN LƯU (RÚT ỐNG)",
                    MoTaNgan = "Kiểm soát nhiễm khuẩn",
                    Url = "/ThayBangOngDanRutOng",
                    ImageUrl = "https://kaapvaal.vn/wp-content/uploads/2025/01/TOP-5-44-600x400.png"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM 3 ĐÚNG KHI THỰC HIỆN CẤP PHÁT THUỐC",
                    MoTaNgan = "Cấp phát thuốc",
                    Url = "/BangKIemThuoc", // Hoặc /BangKiemThuoc như trong modal cũ
                    ImageUrl = "https://cdn.accgroup.vn/wp-content/uploads/2022/03/cap-phat-thuoc.jpeg"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM 3 ĐÚNG KHI THỰC HIỆN THỦ THUẬT/ PHẪU THUẬT",
                    MoTaNgan = "Thủ thuật/Phẫu thuật",
                    Url = "/ThuThuatPhauThuat",
                    ImageUrl = "https://cdn.youmed.vn/tin-tuc/wp-content/uploads/2019/09/bien-chung-thuong-gap-sau-khi-phau-thuat-mo-tri.jpg"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG GIÁM SÁT NGƯỜI BỆNH",
                    MoTaNgan = "Giám sát, Y lệnh thuốc",
                    Url = "/GiamSat",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRDZK8atVm60W6ncap--lyvL8ZGEYxOVrd4ow&s"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM XÁC ĐỊNH CHÍNH XÁC NGƯỜI BỆNH",
                    MoTaNgan = "Xác định người bệnh",
                    Url = "/XacDinhNguoiBenh",
                    ImageUrl = "https://bcp.cdnchinhphu.vn/334894974524682240/2025/6/20/kcb-17504142439561591417987.jpg"
                },
                new DanhSachBangKiem
                {
                    TenBangKiem = "BẢNG KIỂM AN TOÀN PHẪU THUẬT",
                    MoTaNgan = "An toàn phẫu thuật",
                    Url = "/BangKiemAnToanPhauThuat",
                    ImageUrl = "https://bvnguyentriphuong.com.vn/uploads/082021/images/ch%E1%BB%A9c%20n%C4%83ng/an-toan-phau-thuat.jpg"
                },
                // Thêm các bảng kiểm khác mà bạn có ở đây, ví dụ:
            }
            };
            return View(viewModel);
        }
    }
}
