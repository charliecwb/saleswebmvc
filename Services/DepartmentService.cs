using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Configs;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class DepartmentService(ContextConfig _context)
    {
        public async Task<List<Department>> FindAllAsync() {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}