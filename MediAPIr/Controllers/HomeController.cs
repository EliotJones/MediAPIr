namespace MediAPIr.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Cqrs;
    using MediaAPIr.Api.Client;
    using Models;

    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = new HomeModel();

            using (var client = new ApiClient())
            {
                model.Rappers = await client.Send<GetAllRappers, Rapper[]>(new GetAllRappers());
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(HomeModel model)
        {
            using (var client = new ApiClient())
            {
                model.Rappers = await client.Send<GetAllRappers, Rapper[]>(new GetAllRappers());

                if (model.SearchTerm == null)
                {
                    return View(model);
                }

                model.SearchResult = await client.Send<GetRapperByName, Rapper>(new GetRapperByName(model.SearchTerm));
            }

            return View(model);
        }
    }
}