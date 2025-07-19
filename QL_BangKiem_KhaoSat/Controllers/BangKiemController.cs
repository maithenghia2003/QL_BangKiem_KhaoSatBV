using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Data;
using QL_BangKiem_KhaoSat.Models;
using QL_BangKiem_KhaoSat.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using Rotativa.AspNetCore;

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
                        SubSteps = new List<BangKiemSubStepResult>(),

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
        public async Task<IActionResult> List(
    string tenForm = null,
    string title = null,
    string khoa = null,
    string nguoiGiamSat = null,
    string dieuDuongThucHien = null,
    DateTime? fromDate = null,
    DateTime? toDate = null)
        {
            var query = _context.BangKiemEntities.AsQueryable();

            if (!string.IsNullOrEmpty(tenForm))
                query = query.Where(x => x.TenForm.Contains(tenForm));
            if (!string.IsNullOrEmpty(title))
                query = query.Where(x => x.Title.Contains(title));
            if (!string.IsNullOrEmpty(khoa))
                query = query.Where(x => x.Khoa.Contains(khoa));
            if (!string.IsNullOrEmpty(nguoiGiamSat))
                query = query.Where(x => x.NguoiGiamSat.Contains(nguoiGiamSat));
            if (!string.IsNullOrEmpty(dieuDuongThucHien))
                query = query.Where(x => x.DieuDuongThucHien.Contains(dieuDuongThucHien));
            if (fromDate.HasValue)
                query = query.Where(x => x.NgayTao >= fromDate.Value);
            if (toDate.HasValue)
                query = query.Where(x => x.NgayTao <= toDate.Value);

            ViewBag.FormList = await _context.BangKiemEntities.Select(x => x.TenForm).Distinct().ToListAsync();
            ViewBag.KhoaList = await _context.BangKiemEntities.Select(x => x.Khoa).Distinct().ToListAsync();

            var list = await query.OrderByDescending(x => x.NgayTao).ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .ThenInclude(x => x.SubSteps)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return NotFound();
            var danhGiaList = await _context.BangKiemDanhGias
        .Where(x => x.BangKiemId == id)
        .OrderByDescending(x => x.ThoiGian)
        .ToListAsync();
            ViewBag.DanhGiaList = danhGiaList;
            var tenForm = (entity.TenForm ?? "").Split('-')[0].Trim(); // lấy "Form 1" trong "Form 1 - Bảng Kiểm"
            tenForm = tenForm.Replace(" ", "");
            switch (tenForm)
            {
                case "Form1":
                    return View("form1Detail", entity);
                case "Form2":
                    return View("form2Detail", entity);
                case "Form3":
                    return View("form3Detail", entity);
                case "Form4":
                    return View("form4Detail", entity);
                // Thêm case cho các form khác nếu có
                default:
                    return View("form1Detail", entity); // hoặc view mặc định khác
            }
        }
        public async Task<IActionResult> Edit(int id, bool? reuse)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .ThenInclude(x => x.SubSteps)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return NotFound();

            // Lấy danh sách khoa nếu cần chọn lại
            ViewBag.IsReuse = (reuse ?? false);
            ViewBag.KhoaList = _context.Khoas.ToList();
            var tenForm = (entity.TenForm ?? "").Split('-')[0].Trim(); // lấy "Form 1" trong "Form 1 - Bảng Kiểm"
            tenForm = tenForm.Replace(" ", "");
            switch (tenForm)
            {
                case "Form1":
                    return View("form1Edit", entity);
                case "Form2":
                    return View("form2Edit", entity);
                case "Form3":
                    return View("form3Edit", entity);
                case "Form4":
                    return View("form4Edit", entity);
                // ... các form khác
                default:
                    return View("form1Edit", entity); // fallback nếu không khớp form nào
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(BangKiemEntity model)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .ThenInclude(x => x.SubSteps)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null)
                return NotFound();

            entity.Title = model.Title;
            entity.NgayGiamSat = model.NgayGiamSat;
            entity.Khoa = model.Khoa;
            entity.DieuDuongThucHien = model.DieuDuongThucHien ?? "";
            entity.NguoiGiamSat = model.NguoiGiamSat;
            entity.GhiChu = model.GhiChu ?? "";
            entity.Note = model.Note ?? "";
            entity.NhomThaoTacJson = model.NhomThaoTacJson ?? "";

            // Xóa các phần tử cũ trong KetQua
            if (entity.KetQua == null)
            {
                entity.KetQua = new List<BangKiemStepResult>();
            }
            else
            {
                entity.KetQua.Clear();
            }

            // Xử lý an toàn với model.KetQua
            (model.KetQua ?? Enumerable.Empty<BangKiemStepResult>()).ToList().ForEach(step =>
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
                    step.SubSteps.ToList().ForEach(sub =>
                    {
                        newStep.SubSteps.Add(new BangKiemSubStepResult
                        {
                            SubStepName = sub.SubStepName,
                            KetQuaNhom1 = sub.KetQuaNhom1,
                            KetQuaNhom2 = sub.KetQuaNhom2,
                            Diem = sub.Diem
                        });
                    });
                }
                entity.KetQua.Add(newStep);
            });

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

        public async Task<IActionResult> ThongKe(string formKey = null, string khoa = null, int? nam = null, int? quy = null, int? thang = null, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            var query = _context.BangKiemEntities.AsQueryable();

            if (!string.IsNullOrEmpty(formKey))
                query = query.Where(x => x.TenForm == formKey);

            if (!string.IsNullOrEmpty(khoa))
                query = query.Where(x => x.Khoa == khoa);

            // Lọc theo năm
            if (nam.HasValue)
                query = query.Where(x => x.NgayGiamSat.Year == nam.Value);

            // Lọc theo tháng
            if (thang.HasValue)
                query = query.Where(x => x.NgayGiamSat.Month == thang.Value);

            // Lọc theo quý
            if (quy.HasValue)
                query = query.Where(x => (x.NgayGiamSat.Month - 1) / 3 + 1 == quy.Value);

            // Lọc theo ngày từ đến
            if (tuNgay.HasValue)
                query = query.Where(x => x.NgayGiamSat >= tuNgay.Value);
            if (denNgay.HasValue)
                query = query.Where(x => x.NgayGiamSat <= denNgay.Value);

            var bangKiemList = await query.Include(x => x.KetQua).ToListAsync();

            var thongke = bangKiemList
                .GroupBy(x => new
                {
                    x.TenForm,
                    x.Khoa,
                    Nam = x.NgayGiamSat.Year,
                    Quy = (x.NgayGiamSat.Month - 1) / 3 + 1,
                    Thang = x.NgayGiamSat.Month
                })
                .Select(g => new BangKiemThongKeViewModel
                {
                    TenForm = g.Key.TenForm,
                    Khoa = g.Key.Khoa,
                    Nam = g.Key.Nam,
                    Quy = g.Key.Quy,
                    Thang = g.Key.Thang,
                    SoLuongPhieu = g.Count(),
                    DiemTrungBinh = g.Average(x => x.KetQua.Any() ? x.KetQua.Average(kq => kq.Diem ?? 0) : 0),
                    SoLuongDat = g.Count(x => x.KetQua.All(kq => (kq.Diem ?? 0) >= 1)),
                    SoLuongChuaDat = g.Count(x => x.KetQua.Any(kq => (kq.Diem ?? 0) < 1)),
                    TiLeDat = g.Any() ? g.Count(x => x.KetQua.All(kq => (kq.Diem ?? 0) >= 1)) * 100.0 / g.Count() : 0
                }).ToList();

            // Đẩy list khoa, năm, tháng, quý về ViewBag để fill dropdown filter
            ViewBag.KhoaList = await _context.Khoas.Select(k => k.TenKhoa).Distinct().ToListAsync();
            ViewBag.YearList = await _context.BangKiemEntities.Select(x => x.NgayGiamSat.Year).Distinct().OrderByDescending(x => x).ToListAsync();

            return View(thongke);
        }
        public async Task<IActionResult> ExportPdf(int id)
        {
            var entity = await _context.BangKiemEntities
                .Include(x => x.KetQua)
                .ThenInclude(x => x.SubSteps)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return NotFound();

            var tenForm = (entity.TenForm ?? "").Split('-')[0].Trim(); // lấy "Form 1" trong "Form 1 - Bảng Kiểm"
            tenForm = tenForm.Replace(" ", "");
            string viewName;
            switch (tenForm)
            {
                case "Form1":
                    viewName = "form1Detail";
                    break;
                case "Form2":
                    viewName = "form2Detail";
                    break;
                case "Form3":
                    viewName = "form3Detail";
                    break;
                case "Form4":
                    viewName = "form4Detail";
                    break;
                default:
                    viewName = "form1Detail"; // hoặc chọn view mặc định
                    break; // hoặc view mặc định khác
            }

            return new ViewAsPdf(viewName, entity)
            {
                FileName = $"BangKiem_{entity.Id}_{DateTime.Now:yyyyMMddHHmmss}.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            };
        }
        [HttpPost]
        public async Task<IActionResult> AddDanhGia(int bangKiemId, string noiDung)
        {
            if (string.IsNullOrWhiteSpace(noiDung) || noiDung.Length < 3)
                return BadRequest("Nội dung nhận xét quá ngắn.");

            var danhGia = new BangKiemDanhGia
            {
                BangKiemId = bangKiemId,
                NguoiDanhGia = User.Identity?.Name ?? "Khách",
                NoiDung = noiDung.Trim(),
                ThoiGian = DateTime.Now,
                Avatar = $"/img/avatar/{(User.Identity?.Name?.GetHashCode() ?? 0) % 5 + 1}.png" // Ví dụ 5 avatar có sẵn
            };

            _context.BangKiemDanhGias.Add(danhGia);
            await _context.SaveChangesAsync();

            // Trả về partial cập nhật luôn giao diện nhận xét
            var danhGiaList = await _context.BangKiemDanhGias
                .Where(x => x.BangKiemId == bangKiemId)
                .OrderByDescending(x => x.ThoiGian)
                .ToListAsync();

            return PartialView("DanhGiaList", danhGiaList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BangKiemEntity model)
        {
            // Đảm bảo các trường string NOT NULL luôn có giá trị rỗng nếu chưa có dữ liệu
            model.GhiChu = model.GhiChu ?? "";
            model.Note = model.Note ?? "";
            model.NhomThaoTacJson = model.NhomThaoTacJson ?? "";
            model.Title = model.Title ?? "";
            model.DieuDuongThucHien = model.DieuDuongThucHien ?? "";
            model.NguoiGiamSat = model.NguoiGiamSat ?? "";
            model.Khoa = model.Khoa ?? "";
            model.TenForm = model.TenForm ?? "";

            // Reset Id về 0 cho thực thể gốc và các con
            model.Id = 0;
            if (model.KetQua != null)
            {
                foreach (var step in model.KetQua)
                {
                    step.Id = 0;
                    step.StepName = step.StepName ?? "";
                    step.KetQuaLoai = step.KetQuaLoai ?? "";
                    step.LoaiKetQua = step.LoaiKetQua ?? "";

                    if (step.SubSteps != null)
                    {
                        foreach (var sub in step.SubSteps)
                        {
                            sub.Id = 0;
                            sub.SubStepName = sub.SubStepName ?? "";
                        }
                    }
                }
            }
            model.NgayTao = DateTime.Now;
            model.NguoiTao = User.Identity?.Name ?? "System";

            _context.BangKiemEntities.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = model.Id });
        }


    }

}