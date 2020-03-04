namespace Andreys.Services
{
    using System.Collections.Generic;

    using Andreys.Models;
    using Andreys.ViewModels.Products;
    public interface IProductsService
    {
        int Add(ProductAddInputModel productAddInputModel);

        IEnumerable<Product> GetAll();

        Product GetById(int id);

        void DeleteById(int id);
    }
}
