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
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _Barndrepository;

        public BrandService(IGenericRepository<Brand> barndrepository)
        {
            _Barndrepository = barndrepository;
        }

        public async Task AddCategoryAsync(Brand brand)
        {
            await _Barndrepository.AddAsync(brand);
            
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _Barndrepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Brand>> GetAllCategoriesAsync(Brand brand)
        {
            return await _Barndrepository.GetAllAsync();
        }

        public async Task<Brand> GetCategoryByIdAsync(int id)
        {
          return await _Barndrepository.GetByIdAsync(id);
            
        }

        public async Task UpdateCategoryAsync(Brand brand)
        {
            await _Barndrepository.UpdateAsync(brand);
          
        }
    }
}
