namespace SimpleBank.Application.Loans
{
    public class PaymentOverviewVM
    {
        public string LoanAmount { get; set; }
        public int Duration { get; set; }
        public string MonthlyPayment { get; set; }
        public string TotalAmountPaidAsInterestRate { get; set; }
        public string AdministrationFee { get; set; }

        public override string ToString()
        {
            return $@"
----------------------------------------------------------------------
|Loan Amount                        | {LoanAmount}
|---------------------------------------------------------------------
|Durataion                          | {Duration}
|---------------------------------------------------------------------
|Monthly Payment                    | {MonthlyPayment}
|---------------------------------------------------------------------
|Total amount paid as interest rate | {TotalAmountPaidAsInterestRate}
|---------------------------------------------------------------------
|Administration fee                 | {AdministrationFee}
----------------------------------------------------------------------
";
        }
    }
}
