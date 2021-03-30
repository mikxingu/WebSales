using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Models;

namespace WebSalesMVC.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			//ViewData é um Dicionario(conjunto palavra/valor)
			//O atribuito que eu passar para o meu ViewData será chamado na minha View com o nome desse método

			//Mensagem principal da página.
			ViewData["Message"] = "Página em construção.";

			ViewData["DevMessage"] = "Desenvolvido por: ";

			ViewData["Developer"] = "Michel Alves";

			ViewData["Email"] = "michelalvs@gmail.com";

			


			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
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
