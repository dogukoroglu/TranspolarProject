using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.Default
{
	public class _SliderPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
