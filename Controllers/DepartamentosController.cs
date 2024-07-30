using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers {
    public class DepartamentosController : Controller {
        public IActionResult Index() {

            List<Departamento> departamentos = new List<Departamento>();
            departamentos.Add(new Departamento { Id = 5, Nome = "Eletrônicos" });
            departamentos.Add(new Departamento { Id = 2, Nome = "Alimentos" });


            return View(departamentos);
        }
    }
}
