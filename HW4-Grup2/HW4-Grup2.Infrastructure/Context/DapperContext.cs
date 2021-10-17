using Microsoft.EntityFrameworkCore;

namespace HW4_Grup2.Infrastructure.Context
{
    public class DapperContext : DbContext
    {
        public DapperContext(DbContextOptions<DapperContext> options) : base(options) { }

        
    }
}
