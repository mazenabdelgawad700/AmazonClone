using Amazon.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string SKU { get; set; }

        public bool? IsAvailable { get; set; } 

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

    }
}
