using Prova.Repository.TheMovieImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Prova.Web.Controllers
{
    [RoutePrefix("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Index()
        {
            var a = await TheMovie.Instance.ListarFilmes();

            return View(a);
        }

        public async Task<ActionResult> Detalhes(string id)
        {
            var a = await TheMovie.Instance.BuscarFilme(id);
            return View(a);
        }
    }
}