using BussinessObject.Entity;
using Infrastructure.IService;
using Infrastructure.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentingRazorPage.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IRentingTransService _rentingTransService;
        public ProfileModel(ICustomerService customerService, IRentingTransService rentingTransService)
        {
            _customerService = customerService;
            _rentingTransService = rentingTransService;
        }
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public IEnumerable<RentingTransaction> rentingTransactions { get; set; } = default!;
        public IActionResult OnGet()
        {
            var accId = HttpContext.Session.GetString("CustomerID");
            if (accId == null)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                int id = int.Parse(accId);
                Customer = _customerService.GetCustomerById(id);
                rentingTransactions = _rentingTransService.GetRentingHistory(id);
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            var accId = HttpContext.Session.GetString("CustomerID");
            int id = int.Parse(accId);
            try
            {
                var cus = _customerService.GetCustomerById(id);
                if (cus == null)
                {
                    return RedirectToPage("/HomePage");
                }else if(cus.Telephone == Customer.Telephone && cus.CustomerName == Customer.CustomerName)
                {
                    ViewData["notification"] = "Nothing change";
                    rentingTransactions = _rentingTransService.GetRentingHistory(id);
                    return Page();
                }
                else
                {
                    Customer = _customerService.UpdateProfile(id, Customer);
                    rentingTransactions = _rentingTransService.GetRentingHistory(id);
                    ViewData["notification"] = "*Update Successfully";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ViewData["notification"] = ex.Message.ToString();
            }
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("CustomerID");
            return RedirectToPage("/HomePage");
        }
    }
}
