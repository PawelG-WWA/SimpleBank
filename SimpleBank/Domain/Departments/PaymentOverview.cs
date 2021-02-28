namespace SimpleBank.Domain.Departments
{
    /// <summary>
    /// This could be an entity which holds
    /// all payment overviews generated for clients
    /// The entity could hold, for example Id of a client for whom the
    /// overview was generated so the bank could track 
    /// amounts the client is interested in etc.
    /// 
    /// For simplicity, the entity has the same values as the view model
    /// and the default currency for all the money is kr.
    /// </summary>
    public class PaymentOverview
    {
        public double LoanAmount { get; set; }
        public int Duration { get; set; }
        public double MonthlyPayment { get; set; }
        public double TotalAmountPaidAsInterestRate { get; set; }
        public double AdministrationFee { get; set; }
    }
}
