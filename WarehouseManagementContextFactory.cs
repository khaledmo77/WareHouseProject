using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WareHouseProject
{
    public class WarehouseManagementContextFactory : IDesignTimeDbContextFactory<WarehouseManagementContext>
    {
        public WarehouseManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseManagementContext>();
            optionsBuilder.UseSqlServer(@"Server=KHALED\SQLEXPRESS;Database=WarehouseManagementDB;Trusted_Connection=True;");

            return new WarehouseManagementContext(optionsBuilder.Options);
        }
    }
}