using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Data;
using WebSalesMVC.Models;

namespace WebSalesMVC.Services
{
	public class SellerService
	{
		private readonly WebSalesMVCContext _context;

		public SellerService(WebSalesMVCContext context)
		{
			_context = context;
		}

		public List<Seller> FindAll()
		{
			return _context.Seller.ToList();
		}

		public void Insert (Seller obj)
		{
			obj.Department = _context.Department.First(); /*
			                                               * ISSO PREVINE QUE A APLICAÇÃO QUEBRE QUANDO TENTO INSERIR UM VENDEDOR POIS
			                                               * ATRIBUI O PRIMEIRO DEPARTAMENTO AO MEU VENDEDOR
			                                               */
			_context.Add(obj);
			_context.SaveChanges();
		}
	}
}
