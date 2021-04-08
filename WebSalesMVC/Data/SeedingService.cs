using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSalesMVC.Models;

namespace WebSalesMVC.Data
{
	public class SeedingService
	{
		private WebSalesMVCContext _context;

		public SeedingService(WebSalesMVCContext context)
		{
			_context = context;
		}

		public void Seed()
		{
			if (_context.Department.Any() ||
				_context.Seller.Any() ||
				_context.SalesRecord.Any())
			{
				return; // Database already seeded
			}

			//CREATION OF DEPARTMENTS

			Department d1 = new Department(1, "Computers");
			Department d2 = new Department(2, "Eletronics");
			Department d3 = new Department(3, "Food");
			Department d4 = new Department(4, "Construction");

			//CREATION OF SELLERS

			Seller s1 = new Seller(1, "John Doe", "john@sales.com", 1000.0, new DateTime(1998, 4, 21), d1);
			Seller s2 = new Seller(2, "Maria Green", "maria@sales.com", 1000.0, new DateTime(1995, 6, 30), d2);
			Seller s3 = new Seller(3, "Bob Brown", "bob@sales.com", 1000.0, new DateTime(1980, 12, 10), d3);
			Seller s4 = new Seller(4, "Lucas Golden", "lucas@sales.com", 1000.0, new DateTime(1986, 3, 18), d4);

			//CREATION OF SALES RECORDS

			SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 01, 01), 1000.0, Models.Enums.SaleStatus.Billed, s1);
			SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 01, 02), 2000.0, Models.Enums.SaleStatus.Pending, s1);
			SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 01, 03), 3000.0, Models.Enums.SaleStatus.Canceled, s1);
			SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 01, 01), 1000.0, Models.Enums.SaleStatus.Billed, s2);
			SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 01, 02), 2000.0, Models.Enums.SaleStatus.Pending, s2);
			SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 01, 03), 3000.0, Models.Enums.SaleStatus.Canceled, s2);
			SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 01, 01), 1000.0, Models.Enums.SaleStatus.Billed, s3);
			SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 01, 02), 2000.0, Models.Enums.SaleStatus.Pending, s3);
			SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 01, 03), 3000.0, Models.Enums.SaleStatus.Canceled, s3);
			SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 01, 01), 1000.0, Models.Enums.SaleStatus.Billed, s4);
			SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 01, 02), 2000.0, Models.Enums.SaleStatus.Pending, s4);
			SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 01, 03), 3000.0, Models.Enums.SaleStatus.Canceled, s4);

			// SEEDING PROCESS

			_context.Department.AddRange(d1, d2, d3, d4);
			_context.Seller.AddRange(s1, s2, s3, s4);
			_context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12);

			_context.SaveChanges();
		}
	}
}
