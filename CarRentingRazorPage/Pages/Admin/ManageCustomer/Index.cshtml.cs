using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Entity;
using Infrastructure.Service.IService;

namespace CarRentingRazorPage.Pages.Admin.ManageCustomer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public void OnGet()
        {
            Customer = _customerService.GetCustomer();
        }
    }
}
