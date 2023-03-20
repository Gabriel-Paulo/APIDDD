using APIDDD.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace APIDDD.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; private set; }
        public Product(string name, string coderp, decimal price)
        {
            Validation(name, coderp, price);
            Purchases = new List<Purchase>();
        }
        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id < 0, "ID deve ser informado!");
            Id = id;
            Validation(name, codErp, price);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string coderp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(coderp), "Codigo ERP deve ser informado!");
            DomainValidationException.When(price < 0, "Preço deve ser informado!");

            Name = name;
            CodErp = coderp;
            Price = price;
        }
    }
}
