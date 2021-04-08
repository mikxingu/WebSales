using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSalesMVC.Models
{
	public class Seller
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string Email { get; set; }
		public double BaseSalary { get; set; }

		public DateTime BirthDate { get; set; }


		public Department Department { get; set; }

		public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


		//CONSTRUCTORS
		public Seller()
		{

		}

		public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department)
		{
			Id = id;
			Name = name;
			Email = email;
			BaseSalary = baseSalary;
			BirthDate = birthDate;
			Department = department;
		}

		//CUSTOM METHODS

		public void AddSales(SalesRecord sr)
		{
			Sales.Add(sr);
		}

		public void RemoveSales (SalesRecord sr)
		{
			Sales.Remove(sr);
		}

		public double TotalSales(DateTime initialDate, DateTime finalDate)
		{
			return Sales.Where(sr => sr.Date >= initialDate && sr.Date <= finalDate).Sum(sr => sr.Amount);
		}
	}
}
