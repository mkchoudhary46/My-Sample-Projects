using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SOLID.Core.DAO;
using SOLID.Data.Models;
using SOLID.Repository.Repository;

namespace SOLID.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var data = _productRepository.GetProducts();

            var map = data.Select(Mapper.Map<Product, ProductViewModel>);
            return null;
        }
    }

    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
