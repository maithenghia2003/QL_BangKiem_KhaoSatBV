using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_BangKiem_KhaoSat.Data;
using QL_BangKiem_KhaoSat.Models;
using QL_BangKiem_KhaoSat.Middleware;
using System.Linq;

namespace QL_BangKiem_KhaoSat.Controllers
{
    [CustomAuthorize("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult QuanLyNguoiDung()
        {
            var users = _context.Users.Include(u => u.VaiTro).ToList();
            return PartialView("~/Views/Shared/_QuanLyNguoiDung.cshtml", users);
        }


        [HttpPost]
        public IActionResult DuyetTaiKhoan(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.DaDuyet = true;
                _context.LichSuDuyets.Add(new LichSuDuyetEntity
                {
                    UserId = user.Id,
                    HanhDong = "Duyệt",
                    ThoiGian = DateTime.Now,
                    GhiChu = null
                });
                _context.SaveChanges();
            }

            // ✅ Chuyển hướng về trang Admin sau khi duyệt
            return RedirectToAction("Admin", "Admin");
        }

        [HttpPost]
        public IActionResult TuChoiTaiKhoan(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.LichSuDuyets.Add(new LichSuDuyetEntity
                {
                    UserId = user.Id,
                    HanhDong = "Từ chối",
                    ThoiGian = DateTime.Now,
                    GhiChu = null
                });
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Admin", "Admin");
        }

        [HttpGet]
        public IActionResult ChinhSuaTaiKhoan(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var vaiTros = _context.VaiTros.ToList();
            if (user == null) return NotFound();

            ViewBag.VaiTros = vaiTros;
            return View("SuaTaiKhoan", user); // View toàn trang
        }

        [HttpGet]
        public IActionResult LoadSuaTaiKhoan(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var vaiTros = _context.VaiTros.ToList();

            if (user == null) return NotFound();

            ViewBag.VaiTros = vaiTros;
            return PartialView("~/Views/Shared/_SuaTaiKhoan.cshtml", user);
        }

        [HttpPost]
        public IActionResult CapNhatTaiKhoan(UserEntity model)
        {
            var user = _context.Users.Find(model.Id);
            if (user != null)
            {
                user.HoTen = model.HoTen;
                user.Email = model.Email;
                user.VaiTroId = model.VaiTroId;
                _context.SaveChanges();
            }

            return RedirectToAction("QuanLyNguoiDung");
        }

        public IActionResult ChoDuyet()
        {
            var users = _context.Users
                           .Include(x => x.VaiTro)
                           .Where(x => !x.DaDuyet)
                           .ToList();

            return View(users);
        }

        [HttpPost]
        public IActionResult Duyet(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.DaDuyet = true;
                _context.LichSuDuyets.Add(new LichSuDuyetEntity
                {
                    UserId = user.Id,
                    HanhDong = "Duyệt",
                    ThoiGian = DateTime.Now,
                    GhiChu = null
                });
                _context.SaveChanges();
            }
            return RedirectToAction("ChoDuyet");
        }

        [HttpPost]
        public IActionResult TuChoi(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.LichSuDuyets.Add(new LichSuDuyetEntity
                {
                    UserId = user.Id,
                    HanhDong = "Từ chối",
                    ThoiGian = DateTime.Now,
                    GhiChu = null
                });
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("ChoDuyet");
        }

        public IActionResult LichSu()
        {
            var lichSu = _context.LichSuDuyets
                            .Include(l => l.User)
                            .OrderByDescending(l => l.ThoiGian)
                            .ToList();
            return View(lichSu);
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult DanhSachKhoa(int? id)
        {
            var list = _context.Khoas.ToList();
            var form = id.HasValue ? _context.Khoas.Find(id) : new KhoaEntity();
            return PartialView("~/Views/Shared/_DanhSachKhoaPartial.cshtml", Tuple.Create(list, form));
        }

        public IActionResult ThemKhoa()
        {
            var khoaMoi = new KhoaEntity();
            return PartialView("~/Views/Shared/_ThemKhoaPartial.cshtml", khoaMoi);
        }
    }
}
