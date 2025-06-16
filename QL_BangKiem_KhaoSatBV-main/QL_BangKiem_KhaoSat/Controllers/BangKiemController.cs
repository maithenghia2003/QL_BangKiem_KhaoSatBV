using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;
namespace QL_BangKiem_KhaoSatBV.Controllers
{
    public class BangKiemController : Controller
    {
        public IActionResult BangKiem()
        {
            return View();
        }
    }
}
