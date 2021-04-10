﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebSalesMVC.Models;

namespace WebSalesMVC.Services
{
	public class DepartmentService
	{
		private readonly WebSalesMVCContext _context;

		public DepartmentService(WebSalesMVCContext context)
		{
			_context = context;
		}

		public List<Department> FindAll()
		{
			return _context.Department.OrderBy(x => x.Name).ToList();
		}
	}
}
