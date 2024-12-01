using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Service.Interfaces
{
    internal interface IBrandService
    {
        Task<Brand> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Brand>> GetAllCategoriesAsync(Brand brand);
        Task AddCategoryAsync(Brand brand);
        Task UpdateCategoryAsync(Brand brand);
        Task DeleteCategoryAsync(int id);
    }
}
