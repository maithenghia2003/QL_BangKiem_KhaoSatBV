using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;
using QL_BangKiem_KhaoSat.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
            return View(new RegisterModel());
        }

        [HttpPost]
        public IActionResult DangKy(RegisterModel model)
        {
            if (model == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.VaiTros = new SelectList(_db.VaiTros.ToList(), "Id", "TenVaiTro");
                return View(model);
            }

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(model.HoTen))
            {
                ModelState.AddModelError("HoTen", "Vui lòng nhập họ và tên.");
            }
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                ModelState.AddModelError("Email", "Vui lòng nhập email.");
            }
            if (string.IsNullOrWhiteSpace(model.MatKhau))
            {
                ModelState.AddModelError("MatKhau", "Vui lòng nhập mật khẩu.");
            }
            if (model.VaiTroId <= 0) // Thay vì kiểm tra null, kiểm tra giá trị âm hoặc 0
            {
                ModelState.AddModelError("VaiTroId", "Vui lòng chọn vai trò.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.VaiTros = new SelectList(_db.VaiTros.ToList(), "Id", "TenVaiTro");
                return View(model);
            }

            // Kiểm tra email đã tồn tại
            if (_db.Users.Any(u => u.Email.Trim().ToLower() == model.Email.Trim().ToLower()))
            {
                ModelState.AddModelError("Email", "Email đã được sử dụng.");
                ViewBag.VaiTros = new SelectList(_db.VaiTros.ToList(), "Id", "TenVaiTro");
                return View(model);
            }

            // Mã hóa mật khẩu
            if (string.IsNullOrEmpty(model.MatKhau))
            {
                ModelState.AddModelError("MatKhau", "Mật khẩu không được để trống.");
                ViewBag.VaiTros = new SelectList(_db.VaiTros.ToList(), "Id", "TenVaiTro");
                return View(model);
            }
            var hashedPassword = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(model.MatKhau)));

            // Tạo và lưu user
            var user = new UserEntity
            {
                HoTen = model.HoTen.Trim(),
                Email = model.Email.Trim().ToLower(),
                MatKhauHash = hashedPassword,
                VaiTroId = model.VaiTroId, // Gán trực tiếp vì VaiTroId là int
                DaDuyet = false,
                NgayDangKy = DateTime.Now
            };

            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                TempData["Message"] = "Đăng ký thành công. Vui lòng chờ Admin duyệt.";
                return RedirectToAction("DangNhap");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi khi lưu dữ liệu. Vui lòng thử lại.");
                ViewBag.VaiTros = new SelectList(_db.VaiTros.ToList(), "Id", "TenVaiTro");
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult DangNhap()
        {
            return View(new DangNhapModel());
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(DangNhapModel model)
        {
            // Kiểm tra ModelState
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                ModelState.AddModelError("Email", "Vui lòng nhập email.");
                return View(model);
            }
            if (string.IsNullOrWhiteSpace(model.MatKhau))
            {
                ModelState.AddModelError("MatKhau", "Vui lòng nhập mật khẩu.");
                return View(model);
            }

            // Mã hóa mật khẩu để kiểm tra
            var hash = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(model.MatKhau)));
            var user = _db.Users
                .Where(x => x.Email == model.Email.Trim() && x.MatKhauHash == hash)
                .Select(x => new
                {
                    x.Id,
                    x.HoTen,
                    x.Email,
                    x.DaDuyet,
                    VaiTro = x.VaiTro.TenVaiTro
                })
                .FirstOrDefault();

            // Kiểm tra đăng nhập
            if (user == null)
            {
                ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
                return View(model);
            }
            if (!user.DaDuyet)
            {
                ModelState.AddModelError("", "Tài khoản chưa được duyệt bởi Admin.");
                return View(model);
            }

            // Tạo claims và đăng nhập
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.HoTen ?? user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.VaiTro ?? "")
            };
            var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

            // Lưu session (nếu cần)
            HttpContext.Session.SetString("UserName", user.HoTen ?? user.Email);
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("VaiTro", user.VaiTro ?? "");
            HttpContext.Session.SetString("Email", user.Email);

            TempData["Message"] = "Đăng nhập thành công";

            // Điều hướng dựa trên vai trò
            return user.VaiTro == "Admin"
                ? RedirectToAction("Admin", "Admin")
                : RedirectToAction("Form1", "BangKiem");
        }

        [HttpGet]
        [Authorize] // Chỉ cho phép người đã đăng nhập đăng xuất
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            HttpContext.Session.Clear();
            TempData["Message"] = "Đăng xuất thành công";
            return RedirectToAction("Index", "Home");
        }
    }
}