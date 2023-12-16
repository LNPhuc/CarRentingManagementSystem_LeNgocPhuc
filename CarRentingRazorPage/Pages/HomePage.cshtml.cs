using BussinessObject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.IService;

namespace CarRentingRazorPage.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly ICarInformationService _carInformationService;

		public HomePageModel(ICarInformationService carInformationService)
		{
			_carInformationService = carInformationService;
		}
        public List<CarInformation> Cars { get; set; } = default!;
		public IActionResult OnGet()
        {
            Cars = _carInformationService.GetCarInformationTop3();
            return Page();
        }
    }
}
