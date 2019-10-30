using HFMaracay.Core;
using HFMaracay.Core.Configuration;
using HFMaracay.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace HFMaracay.Mssql
{
    public class SqlServerContext : Context
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString(ConnectionStrings.SqlServerConnection));
        }
    }

}
