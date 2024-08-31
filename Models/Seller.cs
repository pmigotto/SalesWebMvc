using System;
using System.Collections.Generic;

namespace SalesWebMvc.Models {
    public class Seller {

        public Seller() { 
        }  
        public int Id { get; set; }
        public string Name { get; set; }  

        public string Email  { get; set; }

        public DateTime BirthDate { get; set; }

        public double BaseSalary { get; set; }

        public Departamento Departament { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departamento dp, ICollection<SalesRecord> sr) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = dp;
            Sales = sr;
        }

        public void addSalles(SalesRecord sales) {
            Sales.Add(sales);
        }

        public void removeSalles(SalesRecord sales) {
            Sales.Remove(sales);
        }


        public double totalSalles(DateTime initial, DateTime final) {
            return 0;
        }
    }
}
