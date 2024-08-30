//using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SalesWebMvc.Models {
    public class Departamento {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departamento(int id, string? nome, ICollection<Seller> sellers) {
            Id = id;
            Nome = nome;
            Sellers = sellers;
        }

        public void addSeller(Seller seller) {
            Sellers.Add(seller);
        }

        public double totalSales (DateTime initial, DateTime final) { 
            
            return 0;
        }
    }
}
