using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Data;
using Microsoft.EntityFrameworkCore;
using QL_BangKiem_KhaoSat.Models;
using QL_BangKiem_KhaoSat.Middleware;

namespace QL_BangKiem_KhaoSat.Controllers
{
    [CustomAuthorize("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IActionResult ChoDuyet()
        {
            if (_db.Users == null)
            {
                TempData["Error"] = "Không thể tải danh sách người dùng do lỗi cơ sở dữ liệu.";
                return View(new List<UserEntity>());
            }

            var users = _db.Users
                           .Include(x => x.VaiTro)
                           .Where(x => !x.DaDuyet)
                           .ToList();

            if (users == null)
            {
                TempData["Error"] = "Không thể tải danh sách tài khoản chờ duyệt.";
                return View(new List<UserEntity>());
            }

            return View(users);
        }

        [HttpPost]
        public IActionResult Duyet(int id)
        {
            if (id <= 0)
            {
                TempData["Error"] = "ID không hợp lệ.";
                return RedirectToAction("ChoDuyet");
            }

            var user = _db.Users.Find(id);
            if (user == null)
            {
                TempData["Error"] = "Tài khoản không tồn tại.";
                return RedirectToAction("ChoDuyet");
            }

            try
            {
                user.DaDuyet = true;
                _db.LichSuDuyets.Add(new LichSuDuyetEntity
                {
                    UserId = user.Id,
                    HanhDong = "Duyệt",
                    ThoiGian = DateTime.Now,
                    GhiChu = null
                });
                _db.SaveChanges();
                TempData["Message"] = "Duyệt tài khoản thành công.";
            }
            catch (DbUpdateException ex)
            {
                TempData["Error"] = "Đã xảy ra lỗi khi lưu thay đổi. Vui lòng thử lại.";
            }

            return RedirectToAction("ChoDuyet");
        }

        [HttpPost]
        public IActionResult TuChoi(int id)
        {
            if (id <= 0)
            {
                TempData["Error"] = "ID không hợp lệ.";
                return RedirectToAction("ChoDuyet");
            }

            var user = _db.Users.Find(id);
            if (user == null)
            {
                TempData["Error"] = "Tài khoản không tồn tại.";
                return RedirectToAction("ChoDuyet");
            }

            try
            {
                _db.LichSuDuyets.Add(new LichSuDuyetEntity
                {
                    UserId = user.Id,
                    HanhDong = "Từ chối",
                    ThoiGian = DateTime.Now,
                    GhiChu = null
                });
                _db.Users.Remove(user);
                _db.SaveChanges();
                TempData["Message"] = "Từ chối và xóa tài khoản thành công.";
            }
            catch (DbUpdateException ex)
            {
                TempData["Error"] = "Đã xảy ra lỗi khi xóa tài khoản. Vui lòng thử lại.";
            }

            return RedirectToAction("ChoDuyet");
        }

        public IActionResult LichSu()
        {
            if (_db.LichSuDuyets == null)
            {
                TempData["Error"] = "Không thể tải lịch sử duyệt do lỗi cơ sở dữ liệu.";
                return View(new List<LichSuDuyetEntity>());
            }

            var lichSu = _db.LichSuDuyets
                            .Include(l => l.User)
                            .OrderByDescending(l => l.ThoiGian)
                            .ToList();

            if (lichSu == null)
            {
                TempData["Error"] = "Không có lịch sử duyệt nào.";
                return View(new List<LichSuDuyetEntity>());
            }

            return View(lichSu);
        }
        [HttpPost]
        public IActionResult XoaLichSu(int id)
        {
            if (id <= 0)
            {
                TempData["Error"] = "ID không hợp lệ.";
                return RedirectToAction("LichSu");
            }

            var lichSu = _db.LichSuDuyets.Find(id);
            if (lichSu == null)
            {
                TempData["Error"] = "Lịch sử không tồn tại.";
                return RedirectToAction("LichSu");
            }

            try
            {
                _db.LichSuDuyets.Remove(lichSu);
                _db.SaveChanges();   
                TempData["Message"] = "Xóa lịch sử thành công.";
            }
            catch (DbUpdateException ex)
            {
                TempData["Error"] = "Đã xảy ra lỗi khi xóa lịch sử. Vui lòng thử lại.";
            }

            return RedirectToAction("LichSu");
        }
        public IActionResult Admin()
        {
            return View();
        }
    }
}