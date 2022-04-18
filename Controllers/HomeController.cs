using Microsoft.AspNetCore.Mvc;
using MiPortafolioWeb.Models;
using MiPortafolioWeb.Servicess;
using System.Diagnostics;

namespace MiPortafolioWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProyectoRepositorio repoProyect;
		private readonly IEmailRepository repoEmail;

		public HomeController(ILogger<HomeController> logger,
			IProyectoRepositorio repoProyect,
			IEmailRepository repoEmail)
		{
			_logger = logger;
			this.repoProyect = repoProyect;
			this.repoEmail = repoEmail;
		}

		public IActionResult Index()
		{
			var proyecto = repoProyect.GetAll().Take(3);
			var listaProyecto = new HomeIndexView()
			{
				Proyectos = proyecto
			};
			return View(listaProyecto);
		}

		public IActionResult Proyectos()
		{
			var proyectos = repoProyect.GetAll();
			return View(proyectos);
		}
		public IActionResult Privacy()
		{
			
			return View();
		}

		[HttpGet]
		public IActionResult Contacto()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Contacto(ContactModel model)
		{
			await repoEmail.Enviar(model);
			return RedirectToAction("Gracias");
		}

		public IActionResult Gracias()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}