using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data;

public class ARESDbContextFactory : IDesignTimeDbContextFactory<ARESDbContext>
{
    public ARESDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ARESDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ARESDB;Trusted_Connection=True;");

        return new ARESDbContext(optionsBuilder.Options);
    }
}