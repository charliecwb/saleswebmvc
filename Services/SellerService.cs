using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Configs;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService(ContextConfig _context)
    {
        public List<Seller> FindAll() {
            return _context.Seller.Include(obj => obj.Department).ToList();
        }

        public void Insert(Seller seller) {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller Find(int id) {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) {
            _context.Seller.Remove(Find(id));
            _context.SaveChanges();
        }
    }
}