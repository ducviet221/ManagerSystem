using api_gateway.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace api_gateway.dbContext;


public class myDbContext : DbContext
{
    public DbSet<myUser> MyUsers { get; set; }
    public DbSet<myInfo> InfoList { get; set; }
    public myDbContext(DbContextOptions options) : base(options)
    {
        
    }
}
