using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Entity;
using Infrastructure.Service.IService;

namespace CarRentingRazorPage.Pages.Admin.ManageCustomer
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public EditModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer =  _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {

            try
            {
                if (Customer.CustomerStatus == 0)
                {
                    ViewData["Message"] = "User is already banned!";
                }
                else
                {
                    _customerService.DeleteCustomer(Customer.CustomerId);
                    ViewData["Message"] = "Ban user successfully!";

                }
                
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                
            }

            return RedirectToPage("./Edit");
        }

        
    }
}
