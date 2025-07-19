using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Data;
using QL_BangKiem_KhaoSat.Models;
using System.Linq;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StepEntity step, string MultipleSteps)
        {
            var formKey = step.FormKey;
            bool isActive = step.IsActive;

            if (!string.IsNullOrWhiteSpace(MultipleSteps))
            {
                // Tách các dòng thành danh sách bước
                var lines = MultipleSteps
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Trim())
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToList();

                // Lấy chỉ số bước kế tiếp
                int nextIndex = _context.StepEntities
                    .Where(s => s.FormKey == formKey)
                    .Select(s => s.StepIndex)
                    .ToList()
                    .DefaultIfEmpty(0)
                    .Max() + 1;

                foreach (var line in lines)
                {
                    var newStep = new StepEntity
                    {
                        FormKey = formKey,
                        StepIndex = nextIndex++,
                        StepName = line,
                        IsActive = isActive
                    };
                    _context.StepEntities.Add(newStep);
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { formKey });
            }

            // Nếu người dùng nhập một bước riêng lẻ
            if (!string.IsNullOrWhiteSpace(step.StepName))
            {
                _context.StepEntities.Add(step);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { formKey });
            }

            ViewBag.FormKey = formKey;
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
        // POST: Xóa vĩnh viễn bước
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var step = _context.StepEntities.Find(id);
            if (step != null)
            {
                _context.StepEntities.Remove(step); // XÓA VĨNH VIỄN
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index), new { formKey = step?.FormKey ?? "Form1" });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BulkAction(List<int> selectedIds, string actionType)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                TempData["Error"] = "Bạn chưa chọn bước nào.";
                return RedirectToAction("Index");
            }

            try
            {
                var steps = _context.StepEntities.Where(s => selectedIds.Contains(s.Id)).ToList();

                switch (actionType)
                {
                    case "activate":
                        foreach (var step in steps)
                        {
                            step.IsActive = true;
                        }
                        _context.SaveChanges();
                        TempData["Success"] = "Đã hiển thị các bước đã chọn.";
                        break;

                    case "deactivate":
                        foreach (var step in steps)
                        {
                            step.IsActive = false;
                        }
                        _context.SaveChanges();
                        TempData["Success"] = "Đã ẩn các bước đã chọn.";
                        break;

                    case "delete":
                        _context.StepEntities.RemoveRange(steps);
                        _context.SaveChanges();
                        TempData["Success"] = "Đã xóa các bước đã chọn.";
                        break;

                    default:
                        TempData["Error"] = "Hành động không hợp lệ.";
                        break;
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Có lỗi xảy ra: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

    }
}
