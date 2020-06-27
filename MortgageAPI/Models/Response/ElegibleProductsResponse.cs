using Models.Dto;
using System.Collections.Generic;

namespace Models.Response
{
    public class EligibleProductsResponse : ResponseBase
    {
        public List<BankDTO> BanksWithProducts { get; set; }
    }
}