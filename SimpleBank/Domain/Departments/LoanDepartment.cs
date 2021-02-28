using SimpleBank.Domain.ValueObjects;
using System;

namespace SimpleBank.Domain.Departments
{
    public class LoanDepartment
    {
        /// <summary>
        /// Business method in business object - the "entity". This entity
        /// could write the calculation in the database for future request or anything else...
        /// </summary>
        /// <returns></returns>
        public PaymentOverview GeneratePaymentOverview(LoanParameters loanParameters)
        {
            var denominator = GetDenominator(loanParameters.InterestRatePeriod);
            var interestRate = loanParameters.AnnualInterestRate / 100;
            var periodicInterestRate = interestRate / denominator;
            var interest = ((decimal)interestRate / denominator) * loanParameters.LoanAmount;

            //LoanAmount/({[(1 + periodicInterestRate)^(duration*period)]-1}/[periodicInterestRate*(1+periodicInterestRate)^(duration*period)])
            var monthlyPayment = loanParameters.LoanAmount / ((decimal)(Math.Pow(1 + periodicInterestRate, loanParameters.DurationOfLoan * denominator) - 1) / (decimal)(periodicInterestRate * Math.Pow(1 + periodicInterestRate, loanParameters.DurationOfLoan * denominator)));

            decimal totalInterest = 0;
            decimal balance = loanParameters.LoanAmount;
            decimal currentInterest = 0;
            decimal currentPrincipal = monthlyPayment - interest;
            decimal percentageFee = loanParameters.LoanAmount * 0.01M;
            decimal administrationFee = percentageFee < 10000 ? percentageFee : 10000;
            while (balance > 0)
            {
                currentInterest = ((decimal)interestRate / denominator) * balance;
                totalInterest += currentInterest;
                currentPrincipal = monthlyPayment - currentInterest;
                balance -= currentPrincipal;
            }

            return new PaymentOverview
            {
                AdministrationFee = Convert.ToDouble(administrationFee),
                Duration = loanParameters.DurationOfLoan,
                LoanAmount = Convert.ToDouble(loanParameters.LoanAmount),
                MonthlyPayment = Convert.ToDouble(monthlyPayment),
                TotalAmountPaidAsInterestRate = Convert.ToDouble(totalInterest),
            };
        }

        private int GetDenominator(InterestRatePeriod interestRatePeriod)
        {
            switch(interestRatePeriod)
            {
                case InterestRatePeriod.Monthly:
                    return 12;
                case InterestRatePeriod.Quarterly:
                    return 3;
                case InterestRatePeriod.Weekly:
                    return 52;
            }

            return 12;
        }
    }
}
