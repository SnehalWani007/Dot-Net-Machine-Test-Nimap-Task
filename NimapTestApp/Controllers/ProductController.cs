using NimapTestApp.Models;
using NimapTestApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NimapTestApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ProductController(IProductServices productServices, ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;

        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 9)
        {
            var products = await _productServices.GetProducts(page, pageSize);
            var totalProducts = await _productServices.GetTotalProducts();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryServices.GetCategories();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productServices.AddProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await _categoryServices.GetCategories();
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productServices.GetProductById(id);
            if (product == null) return NotFound();

            var categories = await _categoryServices.GetCategories();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productServices.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await _categoryServices.GetCategories();
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productServices.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
