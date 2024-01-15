using SalesWebMvc.Configs;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly ContextConfig _context;

        public DepartmentService(ContextConfig context) {
            _context = context;
        }

        public List<Department> FindAll() {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}