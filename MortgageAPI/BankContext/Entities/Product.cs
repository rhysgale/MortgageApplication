using System;
using System.ComponentModel.DataAnnotations;

namespace BankContext
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        public decimal InterestRate { get; set; }
        public MortgageType Type { get; set; }
        public double MaximumLTV { get; set; }

        public virtual Bank Bank { get; set; }
    }
}