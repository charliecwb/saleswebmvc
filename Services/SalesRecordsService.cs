using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Configs;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SalesRecordsService(ContextConfig _context)
    {
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue) {
                result = result.Where(x => x.Date >= minDate);
            }

            if (maxDate.HasValue) {
                result = result.Where(x => x.Date <= maxDate);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderBy(x => x.Date).ToListAsync();
        }
    }
}