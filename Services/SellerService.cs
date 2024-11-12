using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SalesWebMvc.Services.Exceptions;
using System.Data;

namespace SalesWebMvc.Services {
    public class SellerService {

        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context) {

            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller) {

            _context.Add(seller);
            await _context.SaveChangesAsync();

        }

        public async Task<Seller> FindByIdAssync(int id) {
            return await _context.Seller.Include(p => p.Department)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) {

            try {
                var obj = _context.Seller.Find(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }catch (IntegrityException e) {
                throw new IntegrityException("Vendedor possui vendas.\nExclusão não permitida!");            }

        }

        public async Task UpdateAsync(Seller seller) {

            if (!await _context.Seller.AnyAsync(x => x.Id == seller.Id)) {
                throw new Exceptions.NotFoundException("Vendedor não encontrado");
            }
            try {


                _context.Update(seller);
                await _context.SaveChangesAsync();

            }
            catch (Exceptions.DbConcurrencyException ex) {

                throw new Exceptions.DbConcurrencyException(ex.Message);
            }
        }
    }
}
