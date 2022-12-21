using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAll();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
                return NotFound();

            var productDb = await _productService.GetById(id);

            if (productDb == null) 
                return NotFound();

            return View(productDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(product);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
                return NotFound();

            var productDb = await _productService.GetById(id);

            if (productDb == null) 
                return NotFound();

            return View(productDb);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
                return NotFound();

            var productDb = await _productService.GetById(id);

            if (productDb == null) 
                return NotFound();

            return View(productDb);
        }


        [HttpPost(), ActionName("Delete")]
        public IActionResult DeleteComfirm(int? id)
        {
            if (id == null) 
                return NotFound();

            var result = _productService.Remove(id);

            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
