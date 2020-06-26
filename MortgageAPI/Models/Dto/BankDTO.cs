using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class BankDTO
    {
        public string BankName { get; set; }
        public AddressDTO BankAddress { get; set; }

        public List<ProductDTO> AvailableProducts { get; set; }
    }
}
