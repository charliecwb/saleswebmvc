using SalesWebMvc.Configs;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class DepartmentService(ContextConfig _context)
    {
        public List<Department> FindAll() {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}