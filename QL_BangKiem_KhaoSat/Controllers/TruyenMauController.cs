using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class TruyenMauController : Controller
    {
        public IActionResult Index()
        {
            var cacBuocTienHanh = new List<BuocTienHanh>
        {
            new BuocTienHanh { STT = 1, MoTa = "Xác định chính xác người bệnh (3/5 yếu tố)" },
            new BuocTienHanh { STT = 2, MoTa = "Báo và giải thích việc sẽ làm" },
            new BuocTienHanh { STT = 3, MoTa = "Đặt người bệnh ở tư thế thích hợp" },
            new BuocTienHanh { STT = 4, MoTa = "Treo lại chai trên trụ treo" },
            new BuocTienHanh { STT = 5, MoTa = "Bộc lộ vùng tiêm, xác định vị trí tiêm, kê gối (nếu cần) chọn tĩnh mạch to, rõ, thẳng, ít di động" },
            new BuocTienHanh { STT = 6, MoTa = "Sát khuẩn tay" },
            new BuocTienHanh { STT = 7, MoTa = "Mang găng tay sạch" },
            new BuocTienHanh { STT = 8, MoTa = "Buộc garo cách vị trí tiêm 7 - 10 cm" },
            new BuocTienHanh { STT = 9, MoTa = "Sát khuẩn vùng tiêm rộng 5cm" },
            new BuocTienHanh { STT = 10, MoTa = "Kiểm tra dây truyền không có bóng khí trước khi truyền" },
            new BuocTienHanh { STT = 11, MoTa = "Căng da, để mặt vát kim lên trên, đâm kim góc 15 - 30 độ qua da vào tĩnh mạch" },
            new BuocTienHanh { STT = 12, MoTa = "Bóp đầu cao su thấy máu là kim vào đúng tĩnh mạch" },
            new BuocTienHanh { STT = 13, MoTa = "Mở garo, mở khóa cho máu chảy (tốc độ chậm)" },
            new BuocTienHanh { STT = 14, MoTa = "Tháo găng" },
            new BuocTienHanh { STT = 15, MoTa = "Cố định kim và dây truyền" },
            new BuocTienHanh { STT = 16, MoTa = "Làm phản ứng sinh vật Oehlecher\n" +
                                                    "Truyền máu theo tốc độ của y lệnh: 5ml máu đầu tiên.\n" +
                                                    "Truyền chậm 8-10 giọt/phút x 5phút, Nếu không có gì bất thường, chỉnh tốc độ như y lệnh X 20ml máu.\n" +
                                                    "Truyền chậm 8-10 giọt/phút x 5phút, Nếu không có mới truyền theo tốc độ của y lệnh.\n" +
                                                    "Theo dõi sát tình trạng của người bệnh khi làm phản ứng sinh vật: sắc mặt, nôn?, đau đầu? khó thở? rét run, mạch nhanh? yếu? huyết áp hạ? ...\n" +
                                                    "Quan sát tại vị trí truyền: ...\n" +
                                                    "Đảm bảo vô trùng, duy trì sự thông suốt với tĩnh mạch của người bệnh." },
            new BuocTienHanh { STT = 17, MoTa = "Điều chỉnh giọt theo y lệnh" },
            new BuocTienHanh { STT = 18, MoTa = "Theo dõi dấu hiệu sinh tồn: sau 15p và theo dõi đến khi kết thúc" },
            new BuocTienHanh { STT = 19, MoTa = "Ghi giờ bắt đầu lên túi máu" },
            new BuocTienHanh { STT = 20, MoTa = "Dặn dò người bệnh những điều cần thiết và báo điều dưỡng khi:\n" +
                                                    "Máu còn 15 - 20 ml\n" +
                                                    "Máu không chảy\n" +
                                                    "Không tự điều chỉnh khóa\n" +
                                                    "Không cử động mạnh nơi truyền\n" +
                                                    "Nơi tiêm phù, đau...\n" +
                                                    "Phản ứng lạ: sốt, lạnh run, mệt, khó thở ..." },
            new BuocTienHanh { STT = 21, MoTa = "Báo cho người bệnh việc mình đã xong, giúp người bệnh tiện nghi." },
            new BuocTienHanh { STT = 22, MoTa = "Ghi hồ sơ: Thời gian bắt đầu truyền\n" +
                                                    "Số lượng máu/ sản phẩm máu đã truyền, nhóm máu\n" +
                                                    "Đáp ứng của người bệnh với truyền máu.\n" +
                                                    "Tình trạng người bệnh trước, trong và sau khi truyền.\n" +
                                                    "Thời gian kết thúc" }
        };

            return View(cacBuocTienHanh); // Giả sử bạn dùng chung View hoặc có View tương tự
        }

        [HttpPost]
        public IActionResult LuuKetQua(List<KetQuaBuocTienHanh> ketQua)
        {
            // Logic lưu kết quả cho bảng kiểm truyền máu
            // ...
            return Json(new { success = true });
        }
    }
}
