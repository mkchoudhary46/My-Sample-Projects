using System.Collections.Generic;
using SOLID.Core.DAO;

namespace SOLID.Repository.Repository
{
    public interface IProductRepository
    {
        void Add(Product p);
        void Edit(Product p);
        void Remove(int id);
        IEnumerable<Product> GetProducts();
        Product FindById(int id);
    }
}

