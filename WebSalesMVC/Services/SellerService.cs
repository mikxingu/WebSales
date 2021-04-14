﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Data;
using WebSalesMVC.Models;
using Microsoft.EntityFrameworkCore;
using WebSalesMVC.Services.Exceptions;

namespace WebSalesMVC.Services
{
	public class SellerService
	{
		private readonly WebSalesMVCContext _context;

		public SellerService(WebSalesMVCContext context)
		{
			_context = context;
		}

		public async Task<List<Seller>> FindAllAsync()
		{
			return await _context.Seller.ToListAsync();
		}

		public async Task InsertAsync (Seller obj)
		{
			_context.Add(obj);
			await _context.SaveChangesAsync();
		}

		public async Task<Seller> FindByIdAsync(int id)
		{
			return await _context.Seller.Include( obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
			
		}

		public async Task RemoveAsync (int id)
		{
			var obj = await _context.Seller.FindAsync(id);
			_context.Seller.Remove(obj);
			await _context.SaveChangesAsync();

		}

		public async Task UpdateAsync(Seller obj)
		{
			bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
			if (!hasAny)//Essa operação valida se existe um objeto "x" cujo Id seja igual a de um vendedor existente no BD
			{
				throw new NotFoundException("Id not found!");
			}
			try
			{
				_context.Update(obj);
				await _context.SaveChangesAsync();
			}
			
			catch(DbUpdateConcurrencyException e)
			{
				throw new DbConcurrencyException(e.Message);
			}

		}
	}
}
