using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gummi_Bear_Kingdom.Models
{
    public interface IItemRepository
    {
        IQueryable<Product> Items { get; }
        Product Save(Product item);
        Product Edit(Product item);
        void Remove(Product item);

        IQueryable<Review> reviews { get; }
        Review Save(Review item);
        Review Edit(Review item);
    }
}
