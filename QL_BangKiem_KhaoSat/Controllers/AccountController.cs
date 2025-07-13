using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;
using QL_BangKiem_KhaoSat.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            ViewBag.VaiTros = new SelectList(_db.VaiTros.ToList(), "Id", "TenVaiTro");
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.VaiTros = new SelectList(_db.VaiTros.ToList(), "Id", "TenVaiTro"); // PHẢI có lại khi return view
                return View(model);
            }

            var hashedPassword = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(model.MatKhau)));

            var user = new UserEntity
            {
                HoTen = model.HoTen,
                Email = model.Email,
                MatKhauHash = hashedPassword,
                VaiTroId = model.VaiTroId,
                DaDuyet = false,
                NgayDangKy = DateTime.Now
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            TempData["Message"] = "Đăng ký thành công. Vui lòng chờ Admin duyệt.";
            return RedirectToAction("DangNhap");
        }

        [HttpGet]
        public IActionResult DangNhap() => View();

        [HttpPost]
        public IActionResult DangNhap(DangNhapModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var hash = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(model.MatKhau)));
            var user = _db.Users
                .Where(x => x.Email == model.Email && x.MatKhauHash == hash)
                .Select(x => new
                {
                    x.Id,
                    x.HoTen,
                    x.Email,
                    x.DaDuyet,
                    VaiTro = x.VaiTro.TenVaiTro
                })
                .FirstOrDefault();

            if (user == null || !user.DaDuyet)
            {
                TempData["Error"] = "Tài khoản không tồn tại hoặc chưa được duyệt.";
                return View(model);
            }

            // ✅ Ghi session
            HttpContext.Session.SetString("UserName", user.HoTen);
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("VaiTro", user.VaiTro);

            TempData["Message"] = "Đăng nhập thành công";

            // ✅ Điều hướng theo vai trò
            if (user.VaiTro == "Admin")
                return RedirectToAction("ChoDuyet", "Admin");

            // Giám sát viên hoặc Điều dưỡng thì về trang tạo bảng kiểm
            return RedirectToAction("Form1", "BangKiem");
        }
        [HttpGet]
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ session
            return RedirectToAction("Index", "Home"); // Về trang chủ
        }

    }

}
