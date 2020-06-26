using System;

namespace Models.Request
{
    public class ElegibleProductsRequest
    {
        public Guid UserId { get; set; }
        public double HouseValue { get; set; }
        public double Deposit { get; set; }
    }
}
