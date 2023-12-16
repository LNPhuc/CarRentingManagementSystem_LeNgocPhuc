using BussinessObject.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.IService;

namespace CarRentingRazorPage.Pages
{
    public class OffersModel : PageModel
    {
		private readonly ICarInformationService _carInformationService;

		public OffersModel(ICarInformationService carInformationService)
		{
			_carInformationService = carInformationService;
		}

		public List<CarInformation> Cars { get; set; } = default!;
		public IActionResult OnGet()
		{
			Cars = _carInformationService.GetCarInformation();
			return Page();
		}
	}
}
