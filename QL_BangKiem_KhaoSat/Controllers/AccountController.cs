namespace QL_BangKiem_KhaoSat.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    namespace QL_BangKiem_KhaoSat.Controllers
    {
        public class AccountController : Controller
        {
            public IActionResult LoginRegister()
            {
                return View();
            }
            public IActionResult ForgotPassword()
            {
                return View();
            }

        }
    }

}
