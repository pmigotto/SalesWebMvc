﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models {
    public class Department {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() {
        }

        public Department(int id, string name) {
            Id = id;
            Name = name ?? string.Empty;
        }

        public void addSeller(Seller seller) {
            Sellers.Add(seller);
        }

        public double totalSales (DateTime initial, DateTime final) { 
            
            return Sellers.Sum(s => s.totalSalles(initial,final));
        }
    }
}
