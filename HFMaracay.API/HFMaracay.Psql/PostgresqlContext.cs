using HFMaracay.Core;
using HFMaracay.Core.Configuration;
using HFMaracay.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HFMaracay.Psql
{
    public class PostgresqlContext : Context
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppConfiguration.GetConnectionString(ConnectionStrings.PostgresqlConnection));
        }
    }
}
