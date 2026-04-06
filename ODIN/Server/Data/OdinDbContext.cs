using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;


namespace Server.Data
{
    public class OdinDbContext : DbContext
    {
        public DbSet<Offender> Offenders { get; set; }  
        public OdinDbContext(DbContextOptions<OdinDbContext> options) : base(options)
        {

        }
    }
}
