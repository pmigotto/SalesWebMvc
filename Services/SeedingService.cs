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
            if (_context.Departamento.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) {
                return; //banco de dados já populado
            }

            Departamento d1 = new Departamento(1,"Computers");
        }

    }
}
