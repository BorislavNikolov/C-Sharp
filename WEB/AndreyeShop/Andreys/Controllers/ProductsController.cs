namespace Andreys.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;

    using SIS.HTTP;
    using SIS.MvcFramework;
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(ProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductAddInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (inputModel.Name.Length < 4 || inputModel.Name.Length > 20 
                            || string.IsNullOrWhiteSpace(inputModel.Name))
            {
                return this.Error("Name lenght must be between 4 and 20 symbols!");
            }

            if (inputModel.Price <= 0 || string.IsNullOrWhiteSpace(inputModel.Price.ToString()))
            {
                return this.Error("Invalid price!");
            }

            if (string.IsNullOrEmpty(inputModel.Description) || inputModel.Description.Length > 10)
            {
                return this.Error("Description must be less than 10 symbols!");
            }

            var productId = this.productsService.Add(inputModel);

            return this.Redirect($"/Products/Details?id={productId}");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.GetById(id);

            return this.View(product);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.DeleteById(id);

            return this.Redirect("/");
        }
    }
}