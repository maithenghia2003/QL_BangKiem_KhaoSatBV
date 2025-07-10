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
        public AdminController(ApplicationDbContext db) => _db = db;

        public IActionResult ChoDuyet()
        {
            var users = _db.Users
                           .Include(x => x.VaiTro) // đảm bảo load VaiTro
                           .Where(x => !x.DaDuyet)
                           .ToList();

            return View(users);
        }

        [HttpPost]
        public IActionResult Duyet(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
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
            }
            return RedirectToAction("ChoDuyet");
        }
        [HttpPost]
        public IActionResult TuChoi(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
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
            }
            return RedirectToAction("ChoDuyet");
        }
        public IActionResult LichSu()
        {
            var lichSu = _db.LichSuDuyets
                            .Include(l => l.User)
                            .OrderByDescending(l => l.ThoiGian)
                            .ToList();
            return View(lichSu);
        }


    }

}
