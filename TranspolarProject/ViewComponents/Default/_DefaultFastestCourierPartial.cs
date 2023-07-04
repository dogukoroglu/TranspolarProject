using Microsoft.AspNetCore.Mvc;

namespace TranspolarProject.ViewComponents.Default
{
	public class _DefaultFastestCourierPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
