using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models {
    public class Departamento {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departamento() {
        }

        public Departamento(int id, string nome) {
            Id = id;
            Nome = nome ?? string.Empty;
        }

        public void addSeller(Seller seller) {
            Sellers.Add(seller);
        }

        public double totalSales (DateTime initial, DateTime final) { 
            
            return Sellers.Sum(s => s.totalSalles(initial,final));
        }
    }
}
