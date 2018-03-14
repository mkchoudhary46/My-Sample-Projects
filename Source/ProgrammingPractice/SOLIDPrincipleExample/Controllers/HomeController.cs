using System.Web.Mvc;
using SOLID.Services;

namespace SOLIDPrincipleExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var data = _productService.GetProducts();
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return new EmptyResult();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return new EmptyResult();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return new EmptyResult();

        }
    }
}
