namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Andreys.Services;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(ProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var allProducts = productsService.GetAll();

                return this.View(allProducts, "Home");
            }

            return this.View();
        }
    }
}
