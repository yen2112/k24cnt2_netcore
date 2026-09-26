using Microsoft.EntityFrameworkCore;
using NguyenVanYen2410900091_exam.Models;

namespace NguyenVanYen2410900091_exam.Data
{
    public class NvyEmployeeDbContext : DbContext
    {
        public NvyEmployeeDbContext(DbContextOptions<NvyEmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<nvyStudent> HvtStudent { get; set; }
    }
}
