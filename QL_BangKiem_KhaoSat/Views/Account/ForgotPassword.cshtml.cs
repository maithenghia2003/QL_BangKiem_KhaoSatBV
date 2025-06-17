using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QL_BangKiem_KhaoSat.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            // TODO: Thực hiện gửi email reset mật khẩu ở đây
            TempData["Message"] = "Nếu email tồn tại, bạn sẽ nhận được hướng dẫn khôi phục.";
            return Page();
        }
    }
}
