using APIDDD.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APIDDD.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }
        public Purchase() { }
        public Purchase(int productid, int personid)
        {
            Validation(productid, personid);
        }
        public Purchase(int id, int productid, int personid)
        {
            DomainValidationException.When(id <= 0, "Id deve ser informado!");
            Id = id;
            Validation(productid, personid);
        }
        public void Edit(int id, int productid, int personid)
        {
            DomainValidationException.When(id <= 0, "Id deve ser informado!");
            Id = id;
            Validation(productid, personid);
        }
        private void Validation(int productid, int personid)
        {
            DomainValidationException.When(productid <= 0, "Id de produto deve ser informado!");
            DomainValidationException.When(personid <= 0, "Id de pessoa deve ser informado!");

            ProductId = productid;
            PersonId = personid;
            Date = DateTime.Now;
        }
    }
}
