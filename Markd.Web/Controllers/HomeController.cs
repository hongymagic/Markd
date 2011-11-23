using System.Web.Mvc;
namespace Markd.Web.Controllers
{
    using Services.Interfaces;
    using ViewModels;

    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public ActionResult Index()
        {
            return View(new HomeViewModel { Posts = _postService.Posts() });
        }
    }
}
