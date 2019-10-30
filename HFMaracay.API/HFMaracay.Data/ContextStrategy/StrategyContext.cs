using System;
using System.Collections.Generic;
using System.Text;
using HFMaracay.Core.Configuration;
using HFMaracay.Core;
using Microsoft.EntityFrameworkCore;


namespace HFMaracay.Data.ContextStrategy
{
    public class StrategyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databseEngine = AppConfiguration.GetConnectionString(ConnectionStrings.DatabaseEngine);
            switch (databseEngine)
            {
                case "sql":
                    optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString(ConnectionStrings.SqlServerConnection));
                    break;
                case "postgresql":
                    optionsBuilder.UseNpgsql(AppConfiguration.GetConnectionString(ConnectionStrings.PostgresqlConnection));
                    break;
            }
        }
    }
}
