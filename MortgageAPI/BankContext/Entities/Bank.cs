using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankContext
{
    public class Bank
    {
        [Key]
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}