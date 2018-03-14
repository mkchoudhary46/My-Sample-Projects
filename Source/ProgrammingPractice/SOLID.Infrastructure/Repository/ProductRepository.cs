using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SOLID.Core.DAO;

namespace SOLID.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductContext _context;

        public ProductRepository(IProductContext context)
        {
            _context = context;
        }

        public void Add(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void Edit(Product p)
        {
            // _context.Entry(p).State = EntityState.Modified;
        }

        public Product FindById(int id)
        {
            var result = (from r in _context.Products where r.Id == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        public void Remove(int id)
        {
            Product p = _context.Products.Find(id);
            _context.Products.Remove(p);
            _context.SaveChanges();
        }
    }
}
