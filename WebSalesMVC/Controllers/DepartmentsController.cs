using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Models;

namespace WebSalesMVC.Controllers
{
	public class DepartmentsController : Controller
	{
		public IActionResult Index()
		{

			List<Department> departmentList = new List<Department>();

			departmentList.Add(new Department { Id = 1, Name = "Eletrônicos" });
			departmentList.Add(new Department { Id = 2, Name = "Moda" });


			return View(departmentList);
		}
	}
}
