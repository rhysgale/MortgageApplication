using System;

namespace Models.Request
{
    public class EligibleProductsRequest
    {
        public Guid UserId { get; set; }
        public double HouseValue { get; set; }
        public double Deposit { get; set; }
    }
}
