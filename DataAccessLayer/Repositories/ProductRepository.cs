using System.Collections.Generic;
using DataAccessLayer.Entities;
using System.Linq;
using System;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository: IDisposable
    {
        private Context db;
        public ProductRepository()
        {
            db = new Context();
        }

        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public Product Read(int id)
        {
             return db.Products.First(product => product.Id == id);
        }

        public List<Product> ReadAll()
        {
            return db.Products.ToList();
        }

        public void Update(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
