﻿using Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response
{
    public class EligibleProductsResponse
    {
        public List<BankDTO> BanksWithProducts { get; set; }
    }
}
