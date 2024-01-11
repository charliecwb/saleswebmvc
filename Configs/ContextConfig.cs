using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Configs
{
    public class ContextConfig : DbContext
    {
        public required DbSet<Department> Department { get; set; }
        public ContextConfig(DbContextOptions options) : base(options) { }
    }
}