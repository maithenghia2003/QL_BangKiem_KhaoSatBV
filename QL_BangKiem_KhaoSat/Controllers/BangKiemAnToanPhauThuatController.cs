using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class BangKiemAnToanPhauThuatController : Controller
    {
        public IActionResult Index()
        {
            // Tạo một đối tượng model BangKiemAnToanPhauThuat
            var model = new BangKiemAnToanPhauThuat
            {
                // Thông tin chung
                HoTenNguoiBenh = "",
                Tuoi = 0,
                GioiTinh = "",
                MaNguoiBenh = "",
                ChuanDoanTruocMo = "",
                PhongMo = "",
                NgayPhauThuat = DateTime.Now,

                // Các mục kiểm tra theo giai đoạn
                TruocGayMeGayTe = new List<MucKiemTra>
                {
                    new MucKiemTra { MoTa = "Điều dưỡng và BS gây mê, Điều dưỡng dụng cụ, Điều dưỡng gây mê đã tự giới thiệu tên và vai trò?" },
                    new MucKiemTra { MoTa = "Xác nhận họ tên, tuổi, giới và mã người bệnh?" },
                    new MucKiemTra { MoTa = "Xác nhận phương pháp mổ?" },
                    new MucKiemTra { MoTa = "Cam kết mổ?" },
                    new MucKiemTra { MoTa = "Vùng mổ có được đánh dấu không?" },
                    new MucKiemTra { MoTa = "Xác nhận thuốc và trang thiết bị gây mê đầy đủ không?" },
                    new MucKiemTra { MoTa = "Xác nhận monitor hoạt động bình thường không?" },
                    new MucKiemTra { MoTa = "Người bệnh có tiền sử dị ứng không?" },
                    new MucKiemTra { MoTa = "Người bệnh có khó thở hoặc nguy cơ trào ngược?" },
                    new MucKiemTra { MoTa = "Xác nhận nguy cơ mất máu ≥ 500ml (7ml/kg ở trẻ em)?" }
                },
                TruocKhiRachDa = new List<MucKiemTra>
                {
                    new MucKiemTra { MoTa = "Phẫu thuật viên, BS gây mê, Điều dưỡng dụng cụ, Điều dưỡng gây mê đã xác nhận tên và vai trò?" },
                    new MucKiemTra { MoTa = "Xác nhận các thành viên trong kíp đã giới thiệu tên và nhiệm vụ?" },
                    new MucKiemTra { MoTa = "Xác nhận lại họ tên, tuổi, giới và mã người bệnh?" },
                    new MucKiemTra { MoTa = "Kháng sinh dự phòng đã được dùng?" },
                    new MucKiemTra { MoTa = "Xác nhận lại vị trí rạch da?" },
                    new MucKiemTra { MoTa = "Đội chiếu hình ảnh chẩn đoán?" },
                    new MucKiemTra { MoTa = "Đội phẫu thuật viên xác nhận điều kiện cần có về dụng cụ trong mổ?" },
                    new MucKiemTra { MoTa = "Đội với bác sĩ gây mê xác nhận điều kiện cần có về gây mê?" },
                    new MucKiemTra { MoTa = "Đội với điều dưỡng xác nhận điều kiện cần có về dụng cụ, trang thiết bị?" }
                },
                TruocKhiKetThucMo = new List<MucKiemTra>
                {
                    new MucKiemTra { MoTa = "Phẫu thuật viên, BS gây mê, Điều dưỡng dụng cụ, Điều dưỡng gây mê xác nhận tên phẫu thuật?" },
                    new MucKiemTra { MoTa = "Xác nhận đếm gạc, kim, dụng cụ?" },
                    new MucKiemTra { MoTa = "Xác nhận nhãn bệnh phẩm?" },
                    new MucKiemTra { MoTa = "Xác nhận điều kiện cần chú ý về hồi tỉnh và chăm sóc sau mổ?" }
                }
            };

            return View(model);
        }

        // Action để xử lý việc lưu kết quả bảng kiểm (HttpPost)
        [HttpPost]
        public IActionResult LuuKetQua(BangKiemAnToanPhauThuat model)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện logic lưu dữ liệu model vào database hoặc nơi lưu trữ khác
                // Ví dụ:
                // _dbContext.BangKiemAnToanPhauThuats.Add(model);
                // _dbContext.SaveChanges();

                // Sau khi lưu thành công, có thể chuyển hướng đến trang khác
                return RedirectToAction("Index"); // Hoặc trang thông báo thành công
            }

            // Nếu có lỗi validation, trả về view để hiển thị lỗi
            return View("Index", model);
        }
    }
}

