using Amazon.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Entities
{
    public class Cart : BaseEntity
    {
        public int ItemsCount { get; set; }
        public bool IsDeleted { get; set; } 

        public int UserId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }

}
