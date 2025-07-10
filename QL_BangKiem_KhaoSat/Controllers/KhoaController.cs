using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Data;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class KhoaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public KhoaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách khoa
        public IActionResult Index()
        {
            var list = _context.Khoas.ToList();
            return View(list);
        }

        // Form thêm/sửa
        public IActionResult Create(int? id)
        {
            KhoaEntity model = id.HasValue ? _context.Khoas.Find(id) : new KhoaEntity();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(KhoaEntity model)
        {
            if (model.Id == 0)
                _context.Khoas.Add(model);
            else
                _context.Khoas.Update(model);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var khoa = _context.Khoas.Find(id);
            if (khoa != null)
            {
                _context.Khoas.Remove(khoa);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Khoas.Select(x => new { x.Id, x.TenKhoa }).ToList();
            return Json(data);
        }

    }

}
