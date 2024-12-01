using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Service.Interfaces
{
    public  interface  IproductService
    {  
        Task <Product> GetProductByIdAsync(int Id);
        Task <IEnumerable<Product>> GetProductAllAsync(Product product);
        
        Task AddProductAsyn(Product product);
        Task UpadateProductAsyn(int id,Product product);
        Task DeleteProductAsynAsync(int id);

    }
}
