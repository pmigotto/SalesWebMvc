using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System.Collections.Generic;
using SalesWebMvc.Services.Exceptions;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers {
    public class SellersController : Controller {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService) {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index() {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create() {
            var departments = await _departmentService.FindAllAsync();
            //var seller = _sellerService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) {
            //_sellerService.FindAll().First();
            if(!ModelState.IsValid) {
                return View(seller);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não informado" }); 
            }

            var obj = await _sellerService.FindByIdAssync(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Registro não encontrado" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Delete(int id) {
            try 
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }


        public async Task<IActionResult> Details(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não informado" });
            }

            var obj = await _sellerService.FindByIdAssync(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Registro não encontrado" }); ;
            }
            return View(obj);

        }

        public async Task<IActionResult> Edit(int? id) {

            if (id == null) {

                return RedirectToAction(nameof(Error), new {message="Id não informado"});
            }

            var obj = await _sellerService.FindByIdAssync(id.Value);

            if (obj == null) {
                RedirectToAction(nameof(Error), new { message = "Registro não encontrado" });
            }

            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel() { Seller = obj, Departments = departments };

            
            return View(viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Seller seller) {

            if (seller is null) {
                return RedirectToAction(nameof(Error), new { message = "Objeto não encontrado" });
            }
                  
            try {

                await _sellerService.UpdateAsync(seller);
            }
            catch (ApplicationException e) {
                RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Error(string message) {
            var viewModel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            
            return View(viewModel);
        }
    }
}
