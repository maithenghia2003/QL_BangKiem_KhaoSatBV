using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Data;
using QL_BangKiem_KhaoSat.Models;
using QL_BangKiem_KhaoSat.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class BangKiemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BangKiemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("/api/BangKiem/SaveBangKiem")]
        public async Task<IActionResult> SaveBangKiem([FromBody] BangKiemSaveViewModel model)
        {
            try
            {
                if (model == null || model.KetQua == null) return BadRequest();

                var entity = new BangKiemEntity
                {
         
                    TenForm = model.TenForm,
                    Title = model.Title,
                    NgayGiamSat = model.NgayGiamSat,
                    Khoa = model.Khoa,
                    DieuDuongThucHien = model.DieuDuongThucHien,
                    NguoiGiamSat = model.NguoiGiamSat,
                    GhiChu = model.GhiChu ?? "",
                    Note = model.Note ?? "",
                    NhomThaoTacJson = model.NhomThaoTacJson,
                    NgayTao = DateTime.Now,
                    NguoiTao = User.Identity?.Name ?? "System",
                    KetQua = new List<BangKiemStepResult>()
                };

                foreach (var step in model.KetQua)
                {
                    var stepResult = new BangKiemStepResult
                    {
                        StepIndex = step.StepIndex,
                        StepName = step.StepName,
                        KetQuaLoai = step.KetQuaLoai,
                        Diem = step.Diem,
                        KetQuaNhom1 = step.KetQuaNhom1,
                        KetQuaNhom2 = step.KetQuaNhom2,
                        LoaiKetQua = step.LoaiKetQua,
                        SubSteps = new List<BangKiemSubStepResult>()
                    };

                    // Đây là phần bạn đang thiếu:
                    if (step.SubSteps != null)
                    {
                        foreach (var sub in step.SubSteps)
                        {
                            stepResult.SubSteps.Add(new BangKiemSubStepResult
                            {
                                SubStepName = sub.SubStepName,
                                KetQuaNhom1 = sub.KetQuaNhom1,
                                KetQuaNhom2 = sub.KetQuaNhom2,
                                Diem = sub.Diem
                            });
                        }
                    }

                    entity.KetQua.Add(stepResult);
                }


                _context.BangKiemEntities.Add(entity);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, entityId = entity.Id });
            }
            catch (Exception ex)
            {
                // Trả exception ra client để debug nhanh
                return StatusCode(500, ex.ToString());
            }
        }
        public IActionResult Form1()
        {
            var steps = _context.StepEntities
                .Where(x => x.FormKey == "Form1" && x.IsActive)
                .OrderBy(x => x.StepIndex)
                .Select(x => x.StepName)
                .ToList();

            ViewBag.Steps = steps;
            return View();
        }

        // Form 2
        public IActionResult Form2()
        {
            var steps = _context.StepEntities
                .Where(x => x.FormKey == "Form2" && x.IsActive)
                .OrderBy(x => x.StepIndex)
                .Select(x => x.StepName)
                .ToList();

            ViewBag.Steps = steps;
            return View();
        }

        // Form 3
        public IActionResult Form3()
        {
            var steps = _context.StepEntities
                .Where(x => x.FormKey == "Form3" && x.IsActive)
                .OrderBy(x => x.StepIndex)
                .Select(x => x.StepName)
                .ToList();

            ViewBag.Steps = steps ?? new List<string>();
            return View();
        }

        // Form 4
        public IActionResult Form4()
        {
            var steps = _context.StepEntities
                .Where(x => x.FormKey == "Form4" && x.IsActive)
                .OrderBy(x => x.StepIndex)
                .Select(x => x.StepName)
                .ToList();

            ViewBag.Steps = steps ?? new List<string>();
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.BangKiemEntities
                .OrderByDescending(x => x.NgayTao)
                .ToListAsync();
            return View(list);
        }
        public async Task<IActionResult> List()
        {
            var list = await _context.BangKiemEntities
                .OrderByDescending(x => x.NgayTao)
                .ToListAsync();
            return View(list);
        }
        public async Task<IActionResult> Details(int id)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .ThenInclude(x => x.SubSteps)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return NotFound();

            // Tuỳ loại form có thể trả về từng view riêng hoặc 1 view details dùng chung
            return View("form1Detail", entity);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return NotFound();

            // Lấy danh sách khoa nếu cần chọn lại
            ViewBag.KhoaList = _context.Khoas.ToList();

            return View("form1Edit", entity);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(BangKiemEntity model)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null)
                return NotFound();

            entity.Title = model.Title;
            entity.NgayGiamSat = model.NgayGiamSat;
            entity.Khoa = model.Khoa;
            entity.DieuDuongThucHien = model.DieuDuongThucHien;
            entity.NguoiGiamSat = model.NguoiGiamSat;
            entity.GhiChu = model.GhiChu ?? "";
            entity.Note = model.Note ?? "";
            entity.KetQua.Clear();
            foreach (var step in model.KetQua)
            {
                var newStep = new BangKiemStepResult
                {
                    StepIndex = step.StepIndex,
                    StepName = step.StepName,
                    Diem = step.Diem,
                    KetQuaLoai = step.KetQuaLoai ?? "",
                    KetQuaNhom1 = step.KetQuaNhom1,
                    KetQuaNhom2 = step.KetQuaNhom2,
                    LoaiKetQua = step.LoaiKetQua ?? "",
                    SubSteps = new List<BangKiemSubStepResult>()
                };

                if (step.SubSteps != null)
                {
                    foreach (var sub in step.SubSteps)
                    {
                        newStep.SubSteps.Add(new BangKiemSubStepResult
                        {
                            SubStepName = sub.SubStepName,
                            KetQuaNhom1 = sub.KetQuaNhom1,
                            KetQuaNhom2 = sub.KetQuaNhom2,
                            Diem = sub.Diem
                        });
                    }
                }
                entity.KetQua.Add(newStep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = entity.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.BangKiemEntities.FindAsync(id);
            if (entity == null) return NotFound();

            _context.BangKiemEntities.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Form3Detail(int id)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .ThenInclude(x => x.SubSteps)
                .FirstOrDefaultAsync(x => x.Id == id && x.TenForm == "Form3");

            if (entity == null) return NotFound();
            return View("form3Detail", entity);
        }

        // Action EDIT cho Form3
        public async Task<IActionResult> Form3Edit(int id)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .ThenInclude(x => x.SubSteps)
                .FirstOrDefaultAsync(x => x.Id == id && x.TenForm == "Form3");

            if (entity == null) return NotFound();

            ViewBag.KhoaList = _context.Khoas.ToList();
            return View("form3Edit", entity);
        }

        // [HttpPost] EDIT cho Form3
        [HttpPost]
        public async Task<IActionResult> Form3Edit(BangKiemEntity model)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null)
                return NotFound();

            // Update fields
            entity.Title = model.Title;
            entity.NgayGiamSat = model.NgayGiamSat;
            entity.Khoa = model.Khoa;
            entity.DieuDuongThucHien = model.DieuDuongThucHien;
            entity.NguoiGiamSat = model.NguoiGiamSat;
            entity.GhiChu = model.GhiChu ?? "";
            entity.Note = model.Note ?? "";
            entity.NhomThaoTacJson = model.NhomThaoTacJson;

            // Update từng step (đơn giản nhất là clear rồi add lại, hoặc update theo index)
            entity.KetQua.Clear();
            foreach (var step in model.KetQua)
            {
                var newStep = new BangKiemStepResult
                {
                    StepIndex = step.StepIndex,
                    StepName = step.StepName,
                    Diem = step.Diem,
                    KetQuaLoai = step.KetQuaLoai ?? "",
                    KetQuaNhom1 = step.KetQuaNhom1,
                    KetQuaNhom2 = step.KetQuaNhom2,
                    LoaiKetQua = step.LoaiKetQua ?? "",
                    SubSteps = new List<BangKiemSubStepResult>()
                };

                // Nếu có SubSteps
                if (step.SubSteps != null)
                {
                    foreach (var sub in step.SubSteps)
                    {
                        newStep.SubSteps.Add(new BangKiemSubStepResult
                        {
                            SubStepName = sub.SubStepName,
                            KetQuaNhom1 = sub.KetQuaNhom1,
                            KetQuaNhom2 = sub.KetQuaNhom2,
                            Diem = sub.Diem
                        });
                    }
                }
                entity.KetQua.Add(newStep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Form3Detail", new { id = entity.Id });
        }
        public async Task<IActionResult> ThongKe(string formKey = null, string khoa = null, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            var query = _context.BangKiemEntities.AsQueryable();

            if (!string.IsNullOrEmpty(formKey))
                query = query.Where(x => x.TenForm == formKey);

            if (!string.IsNullOrEmpty(khoa))
                query = query.Where(x => x.Khoa == khoa);

            if (tuNgay.HasValue)
                query = query.Where(x => x.NgayGiamSat >= tuNgay.Value);
            if (denNgay.HasValue)
                query = query.Where(x => x.NgayGiamSat <= denNgay.Value);

            var bangKiemList = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .Where(x => x.NgayGiamSat >= tuNgay && x.NgayGiamSat <= denNgay)
                .ToListAsync();

            var thongke = bangKiemList
                .GroupBy(x => new { x.TenForm, x.Khoa })
                .Select(g => new BangKiemThongKeViewModel
                {
                    TenForm = g.Key.TenForm,
                    Khoa = g.Key.Khoa,
                    SoLuongPhieu = g.Count(),
                    DiemTrungBinh = g.Average(x => x.KetQua.Any() ? x.KetQua.Average(kq => kq.Diem ?? 0) : 0),
                    SoLuongDat = g.Count(x => x.KetQua.All(kq => (kq.Diem ?? 0) >= 1)),
                    SoLuongChuaDat = g.Count(x => x.KetQua.Any(kq => (kq.Diem ?? 0) < 1)),
                    TiLeDat = g.Any() ? g.Count(x => x.KetQua.All(kq => (kq.Diem ?? 0) >= 1)) * 100.0 / g.Count() : 0
                }).ToList();


            // Gửi dữ liệu qua ViewBag hoặc Model tuỳ bạn
            return View(thongke);
        }


    }

}
