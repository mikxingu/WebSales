﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSalesMVC.Models;

namespace WebSalesMVC.Data
{
    public class WebSalesMVCContext : DbContext
    {
        public WebSalesMVCContext (DbContextOptions<WebSalesMVCContext> options)
            : base(options)
        {
        }

        public DbSet<WebSalesMVC.Models.Department> Department { get; set; }
    }
}
