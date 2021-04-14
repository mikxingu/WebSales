﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebSalesMVC.Models
{
	public class Seller
	{
		public int Id { get; set; }

		public string Name { get; set; }


		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "Base Salary")]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:F2}")]
		public double BaseSalary { get; set; }

		[Display(Name = "Birth Date")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime BirthDate { get; set; }


		public Department Department { get; set; }
		public int DepartmentId { get; set; }

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
