using NimapTestApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NimapTestApp.Services
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
