using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevCore.Identity.Data
{
    public class DevCoreAppDbContext : IdentityDbContext
    {
        public DevCoreAppDbContext(DbContextOptions<DevCoreAppDbContext> options) : base(options) { }
    }
}
