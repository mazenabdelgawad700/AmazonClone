using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using Amazon.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Service.Implementations
{
    internal class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryrepository;

        public CategoryService(IGenericRepository<Category> categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryrepository.AddAsync(category);
           
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryrepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(Category category)
        {
            return await _categoryrepository.GetAllAsync(c=> c.Products);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryrepository.GetByIdAsync(id,c=> c.Products);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
         await _categoryrepository.UpdateAsync(category);
        }
    }
}
