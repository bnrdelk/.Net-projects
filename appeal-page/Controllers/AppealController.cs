using Microsoft.AspNetCore.Mvc;

namespace appeal_page.Controllers
{
    public class AppealController : Controller
    {
        // localhost/appeal
        // localhost/appeal/index
        public string Index()
        {
            return "appeal/index";
        }
    }
}