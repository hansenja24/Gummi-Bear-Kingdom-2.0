using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gummi_Bear_Kingdom.Models
{
    public class EFItemRepository : IItemRepository
    {
        GummiBearKingdomDbContext db;

        //If we don't provide an argument when instantiating new instances of EFItemRepository, the constructor without an argument in its method signature is used
        public EFItemRepository()
        {
            db = new GummiBearKingdomDbContext();
        }

        //If we do provide an argument when instantiating a new instance, the constructor with an argument in its method signature is automatically used.
        public EFItemRepository(GummiBearKingdomDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Product> Items
        { get { return db.Products; } }

        public Product Save(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
            return item;
        }

        public Product Edit(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public void Remove(Product item)
        {
            db.Products.Remove(item);
            db.SaveChanges();
        }

        public void ClearAll()
        {
            List<Product> allItem = db.Products.ToList();
            db.Products.RemoveRange(allItem);
            db.SaveChanges();
        }

        public IQueryable<Review> reviews
        { get { return db.Reviews; } }

        public Review Save(Review item)
        {
            db.Reviews.Add(item);
            db.SaveChanges();
            return item;
        }

        public Review Edit(Review item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public void Remove(Review item)
        {
            db.Reviews.Remove(item);
            db.SaveChanges();
        }

    }


}
