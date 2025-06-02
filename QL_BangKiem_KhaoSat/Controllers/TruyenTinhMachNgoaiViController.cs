using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class TruyenTinhMachNgoaiViController : Controller
    {
        public IActionResult Index()
        {
            var cacBuocTienHanh = new List<BuocTienHanh>
        {
            new BuocTienHanh { STT = 1, MoTa = "Xác định chính xác người bệnh lần thứ 2" },
            new BuocTienHanh { STT = 2, MoTa = "Đặt người bệnh ở tư thế thích hợp, bộc lộ vị trí tiêm" },
            new BuocTienHanh { STT = 3, MoTa = "Chọn tĩnh mạch to, rõ, thẳng, ít di động, tráng khớp" },
            new BuocTienHanh { STT = 4, MoTa = "Sát khuẩn tay bằng dung dịch rửa tay nhanh" },
            new BuocTienHanh { STT = 5, MoTa = "Mang găng tay" },
            new BuocTienHanh { STT = 6, MoTa = "Buộc garo cách vùng tiêm 7 - 10 cm, dặn NB nắm tay lại" },
            new BuocTienHanh { STT = 7, MoTa = "Sát khuẩn vùng tiêm hình xoắn ốc từ rộng ra 5cm hoặc dọc theo tĩnh mạch (sát khuẩn cho đến khi sạch)" },
            new BuocTienHanh { STT = 8, MoTa = "Kiểm tra dây truyền không có khí trước khi truyền. Tiến hành đâm kim" },
            new BuocTienHanh { STT = 9, MoTa = "Tay không thuận dùng ngón cái căng da phía dưới chỗ TM chọn để TM ít bị lệch.\n" +
                                               "Tay thuận cầm kim đưa vào TM, kim hướng mặt vát lên trên, đâm kim xuyên qua da," +
                                               " chếch 1 góc 15 - 30 so với mặt da vào hết mặt vát của kim," +
                                               " tiếp tục hạ kim xuống song song TM." },
            new BuocTienHanh { STT = 10, MoTa = "Sau đó lùi nòng xem có máu không, nếu có máu thì cùng lúc đẩy kim nhẹ nhàng vào lòng mạch và nhanh chóng mở garo, nói người bệnh buông tay ra." },
            new BuocTienHanh { STT = 11, MoTa = "Gắn dây truyền đã chuẩn bị vào kim luồn, mở khóa cho dịch chảy vào TM." },
            new BuocTienHanh { STT = 12, MoTa = "Quan sát nơi tiêm, che đầu tiêm bằng băng keo cá nhân." },
            new BuocTienHanh { STT = 13, MoTa = "Dán băng keo cố định ở chuôi kim. Cố định dây truyền chắc chắn" },
            new BuocTienHanh { STT = 14, MoTa = "Tháo găng tay" },
            new BuocTienHanh { STT = 15, MoTa = "Điều chỉnh đốc độ truyền theo y lệnh" },
            new BuocTienHanh { STT = 16, MoTa = "Ghi giờ bắt đầu lên chai" },
            new BuocTienHanh { STT = 17, MoTa = "Để NB ở tư thế thích hợp" },
            new BuocTienHanh { STT = 18, MoTa = "Dặn dò người bệnh những điều cần thiết và báo ĐD ngay:\n" +
                                                    "- Khi dịch truyền hết;\n" +
                                                    "- Nếu dịch truyền không chảy;\n" +
                                                    "- Không tự ý mở khóa cho nước chảy nhanh;\n" +
                                                    "- Không cử động mạnh nơi đặt kim;\n" +
                                                    "- Nơi tiêm phù, đau;\n" +
                                                    "- Khi cảm thấy có dấu hiệu lạ; lạnh run, mệt khó thở..." },
            new BuocTienHanh { STT = 19, MoTa = "Báo cho người bệnh biết về việc mình đã xong, giúp người bệnh tiện nghi." },
            new BuocTienHanh { STT = 20, MoTa = "Thu dọn dụng cụ, xử lý rác theo đúng quy định." }
        };

            return View(cacBuocTienHanh); // Giả sử bạn dùng chung View hoặc có View tương tự
        }

        [HttpPost]
        public IActionResult LuuKetQua(List<KetQuaBuocTienHanh> ketQua)
        {
            // Logic lưu kết quả cho bảng kiểm truyền tĩnh mạch ngoại vi
            // ...
            return Json(new { success = true });
        }
    }
}
