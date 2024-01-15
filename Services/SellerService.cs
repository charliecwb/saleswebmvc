using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Configs;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService(ContextConfig _context)
    {
        public async Task<List<Seller>> FindAllAsync() {
            return await _context.Seller.Include(obj => obj.Department).ToListAsync();
        }

        public async Task InsertAsync(Seller seller) {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindAsync(int id) {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) {
            _context.Seller.Remove(await FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj) {
            if (!await _context.Seller.AnyAsync(x => x.Id == obj.Id)) {
                throw new NotFoundException("Id not found");
            }

            try {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException e) {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}