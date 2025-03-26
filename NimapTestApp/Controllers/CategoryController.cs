using Microsoft.AspNetCore.Mvc;
using NimapTestApp.Models;
using NimapTestApp.Services;
using System.Threading.Tasks;

namespace NimapTestApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryServices.GetCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if(ModelState.IsValid)
            {
                await _categoryServices.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        } 

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryServices.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                await _categoryServices.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryServices.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
