using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentingRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty] public String Email { get; set; }
        [BindProperty] public String Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var account = _accountService.Login(Email, Password);
            var admin = _accountService.GetAdminAccount(Email, Password);
    
            if(admin is true)
            {
                return RedirectToPage("/Admin/AdminDashboard");
            }
            else if (account == null)
            {
                ViewData["notification"] = "Tài khoản không tồn tại";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("CustomerID", account.CustomerId.ToString());
                return RedirectToPage("/HomePage");
            }
        }
    }
}
