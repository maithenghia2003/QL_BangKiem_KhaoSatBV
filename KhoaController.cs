using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Data;
using QL_BangKiem_KhaoSat.Models;
using System.Linq;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class KhoaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhoaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách khoa và thông tin khoa cần sửa (nếu có)
        public IActionResult Index(int? id)
        {
            var list = _context.Khoas.ToList();
            var form = id.HasValue ? _context.Khoas.Find(id) : new KhoaEntity();
            return View(Tuple.Create(list, form));
        }

        // Thêm mới hoặc cập nhật Khoa
        [HttpPost]
        public IActionResult Save(KhoaEntity model)
        {
            if (model.Id == 0)
                _context.Khoas.Add(model);
            else
                _context.Khoas.Update(model);

            _context.SaveChanges();

            return Redirect("https://localhost:7223/Admin/Admin#");
        }

        // Xóa khoa - dùng fetch API POST từ JS
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var khoa = _context.Khoas.Find(id);
            if (khoa == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Không tìm thấy khoa để xóa."
                });
            }

            _context.Khoas.Remove(khoa);
            _context.SaveChanges();
            return Redirect("https://localhost:7223/Admin/Admin#");
        }
    }
}
