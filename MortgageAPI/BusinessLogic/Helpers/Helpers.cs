namespace BusinessLogic.Helpers
{
    public static class Helpers
    {
        public static double CalculateLoanToValue(double deposit, double houseValue)
        {
            var amountNeeded = houseValue - deposit;

            return (amountNeeded / houseValue) * 100;
        }
    }
}
