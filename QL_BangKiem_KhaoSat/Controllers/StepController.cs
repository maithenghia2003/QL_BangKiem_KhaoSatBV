using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Data;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class StepController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StepController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách bước theo form
        public IActionResult Index(string formKey = "Form1")
        {
            var steps = _context.StepEntities
                .Where(x => x.FormKey == formKey)
                .OrderBy(x => x.StepIndex)
                .ToList();
            ViewBag.FormKey = formKey;
            return View(steps);
        }

        // GET: Tạo bước mới
        public IActionResult Create(string formKey = "Form1")
        {
            ViewBag.FormKey = formKey;
            return View();
        }

        // POST: Tạo bước mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StepEntity step)
        {
            if (ModelState.IsValid)
            {
                _context.StepEntities.Add(step);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { formKey = step.FormKey });
            }
            ViewBag.FormKey = step.FormKey;
            return View(step);
        }

        // GET: Sửa bước
        public IActionResult Edit(int id)
        {
            var step = _context.StepEntities.Find(id);
            if (step == null) return NotFound();
            ViewBag.FormKey = step.FormKey;
            return View(step);
        }

        // POST: Sửa bước
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StepEntity step)
        {
            if (ModelState.IsValid)
            {
                _context.StepEntities.Update(step);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { formKey = step.FormKey });
            }
            ViewBag.FormKey = step.FormKey;
            return View(step);
        }

        // GET: Xác nhận xóa bước
        public IActionResult Delete(int id)
        {
            var step = _context.StepEntities.Find(id);
            if (step == null) return NotFound();
            return View(step);
        }

        // POST: Xóa (ẩn) bước
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var step = _context.StepEntities.Find(id);
            if (step != null)
            {
                step.IsActive = false;
                _context.StepEntities.Update(step);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index), new { formKey = step?.FormKey ?? "Form1" });
        }
    }
}
