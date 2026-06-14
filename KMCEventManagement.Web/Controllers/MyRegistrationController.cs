using Microsoft.AspNetCore.Mvc;

namespace KMCEventManagement.Web.Controllers
{
    public class MyRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}