using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers {
    public class SallesRecordsController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult SampleSearch() {
            return View();
        }
        public IActionResult GroupingSearch() {
            return View();
        }
    }
}
