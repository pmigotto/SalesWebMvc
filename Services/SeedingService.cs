using SalesWebMvc.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using System.Net.Http.Headers;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services {
    public class SeedingService {

        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context) {

            _context = context;

        }


        public void Seed() {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) {
                return; //banco de dados já populado
            }

            Department d1 = new Department(1,"Computers");
        }

    }
}
