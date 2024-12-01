using Amazon.Core.Entities;
using Amazon.Infrastructure.Repositories;
using Amazon.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Service.Implementations
{
    internal class ProductService : IproductService
    {
        private readonly ProductRepository _productrepository;

        public ProductService(ProductRepository productrepository)
        {
            _productrepository = productrepository;
        }

        public async Task AddProductAsyn(Product product)
        {
            await _productrepository.AddProductAsync(product);
        }

        public async Task DeleteProductAsynAsync(int id)
        {
            var porduct = await _productrepository.GetProductByIdAsync(id);
            if (porduct != null) 
            {
                await _productrepository.DeleteProductAsync(porduct);
            }
        }

        public async Task<IEnumerable<Product>> GetProductAllAsync(Product product)
        {
          return  await _productrepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
           return await _productrepository.GetProductByIdAsync(Id);
        }

        public async Task UpadateProductAsyn(int id, Product product)
        {
           await _productrepository.UpdateProductAsync(id,product);
        
        }
    }
}
