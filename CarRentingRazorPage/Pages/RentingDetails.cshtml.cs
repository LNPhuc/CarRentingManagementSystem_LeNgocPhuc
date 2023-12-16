using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Entity;
using Infrastructure.IService;

namespace CarRentingRazorPage.Pages
{
    public class RentingDetailsModel : PageModel
    {
        private readonly IRentingTransService _rentingTransService;

        public RentingDetailsModel(IRentingTransService rentingTransService)
        {
            _rentingTransService = rentingTransService;
        }

        public List<RentingDetail> RentingDetail { get;set; } = default!;

        public IActionResult OnGet(int id)
        {
            if(id != null)
            {
                RentingDetail = _rentingTransService.GetRentingDetailsById(id);
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
