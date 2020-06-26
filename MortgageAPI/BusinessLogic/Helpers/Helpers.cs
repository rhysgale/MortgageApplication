namespace BusinessLogic.Helpers
{
    public static class Helpers
    {
        /// <summary>
        /// Returns 0.1 for 10%, 0.2 for 20% etc
        /// </summary>
        /// <param name="deposit"></param>
        /// <param name="houseValue"></param>
        /// <returns></returns>
        public static double CalculateLoanToValue(double deposit, double houseValue)
        {
            var amountNeeded = houseValue - deposit;

            return amountNeeded / houseValue;
        }
    }
}
