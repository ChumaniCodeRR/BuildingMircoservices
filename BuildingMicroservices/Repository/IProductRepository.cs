using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingMicroservices.Models;

namespace BuildingMicroservices.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProductByID(int ProductId);

        void CreateProduct(Product Product);

        void DeleteProduct(int ProdcutId);

        void EditProduct(Product Product);

    }
}
