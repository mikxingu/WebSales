﻿using System;


namespace WebSalesMVC.Services.Exceptions
{
	public class IntegrityException : ApplicationException
	{
		public IntegrityException(string message) : base(message)
		{

		}
	}
}
