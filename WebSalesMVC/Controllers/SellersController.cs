﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Models;
using WebSalesMVC.Models.ViewModels;
using WebSalesMVC.Services;
using WebSalesMVC.Services.Exceptions;

namespace WebSalesMVC.Controllers
{
	public class SellersController : Controller
	{
		private readonly SellerService _sellerService;
		private readonly DepartmentService _departmentService;

		public SellersController (SellerService sellerService, DepartmentService departmentService) 
		{
			_sellerService = sellerService;
			_departmentService = departmentService;
		}

		public async Task<IActionResult> Index()
		{
			var list = await _sellerService.FindAllAsync();
			return View(list);
		}

		public async Task<IActionResult> Create()
		{
			var departments = await _departmentService.FindAllAsync();
			var viewModel = new SellerFormViewModel { Departments = departments};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Seller seller)

		{
			if (!ModelState.IsValid)
			{
				var departments = await _departmentService.FindAllAsync();
				var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
				return View(viewModel);
			}
			await _sellerService.InsertAsync(seller);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { errorMessage = "Id not found!"});
			}

			var obj = await _sellerService.FindByIdAsync(id.Value);
			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { errorMessage = "Id not provided!" });
			}

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			await _sellerService.RemoveAsync(id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { errorMessage = "Id not provided!" });
			}

			var obj = await _sellerService.FindByIdAsync(id.Value);
			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { errorMessage = "Id not found!" });
			}

			return View(obj);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { errorMessage = "Id not provided!" });
			}

			var obj = await _sellerService.FindByIdAsync(id.Value);
			if(obj == null)
			{
				return RedirectToAction(nameof(Error), new { errorMessage = "Id not found!" });
			}

			List<Department> departments = await _departmentService.FindAllAsync();
			SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Seller seller)
		{
			if (!ModelState.IsValid)
			{
				var departments = await _departmentService.FindAllAsync();
				var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
				return View(viewModel);
			}
			if (id != seller.Id)
			{
				return RedirectToAction(nameof(Error), new { errorMessage = "Seller Id Mismatch." });
			}

			try
			{
				await _sellerService.UpdateAsync(seller);
				return RedirectToAction(nameof(Index));
			}
			catch (ApplicationException e)
			{
				return RedirectToAction(nameof(Error), new { errorMessage = e.Message });
			}
		}

		public IActionResult Error(string errorMessage)
		{
			var viewModel = new ErrorViewModel { Message = errorMessage, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
			return View(viewModel);
		}
	}
}