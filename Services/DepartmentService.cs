using SalesWebMvc.Data;
using System.Collections.Generic;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace SalesWebMvc.Services {
    public class DepartmentService {

        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context) {
            _context = context;
        }

        public List<Department> FindAll() {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }  
    }
}
