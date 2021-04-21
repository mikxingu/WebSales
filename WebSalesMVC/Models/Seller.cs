using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebSalesMVC.Models
{
	public class Seller
	{
		public int Id { get; set; }


		[Required(ErrorMessage = "{0} is required!")]
		[StringLength(30,MinimumLength = 3,ErrorMessage = "{0} must be between {2} to {1} characters long.")]
		public string Name { get; set; }


		[Required(ErrorMessage = "Enter a valid email!")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "Base Salary")]
		[Range(100, 50000, ErrorMessage = "{0} must be between {2} and {1}!")]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:F2}")]
		[Required(ErrorMessage = "{0} is required!")]
		public double BaseSalary { get; set; }

		[Display(Name = "Birth Date")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		[Required(ErrorMessage = "{0} is required!")]
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
