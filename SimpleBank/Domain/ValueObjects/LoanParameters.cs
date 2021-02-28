namespace SimpleBank.Domain.ValueObjects
{
    public class LoanParameters
    {
        public decimal LoanAmount { get; private set; }
        public int DurationOfLoan { get; private set; }
        public double AnnualInterestRate { get; private set; }
        public InterestRatePeriod InterestRatePeriod { get; private set; }

        public LoanParameters(decimal loanAmount, int durationOfLoan, double annualInterestRate, InterestRatePeriod interestRatePeriod)
        {
            LoanAmount = loanAmount;
            DurationOfLoan = durationOfLoan;
            AnnualInterestRate = annualInterestRate;
            InterestRatePeriod = interestRatePeriod;
        }
    }
}
