using SimpleBank.Application.Abstract;
using SimpleBank.Domain;
using SimpleBank.Domain.Departments;
using SimpleBank.Domain.ValueObjects;
using System;
using System.Globalization;

namespace SimpleBank.Application.Loans
{
    public class GeneratePaymentOverviewQueryHandler : IRequestHandler<GeneratePaymentOverviewQuery, PaymentOverviewVM>
    {
        private readonly IValidator<GeneratePaymentOverviewQuery> _validator;
        private readonly decimal _defaultLoanAmount = 500000;
        private readonly int _defaultDurationOfLoan = 10;
        private readonly double _defaultAnnualInterestRate = 5;
        private readonly InterestRatePeriod _defaultInterestRatePeriod = InterestRatePeriod.Monthly;

        public GeneratePaymentOverviewQueryHandler()
        {
            _validator = ValidatorFactory.CreateValidator<GeneratePaymentOverviewQuery>();
        }

        public PaymentOverviewVM Handle(GeneratePaymentOverviewQuery model)
        {
            _validator.Validate(model);

            // obviously, there should be some code
            // that requests entities from database, but as it is
            // a demo, I gave myself permission to create new objects
            // by hand
            var danske = new Bank
            {
                LoanDepartment = new LoanDepartment()
            };

            var loanParameters = model.LoanTerms.Count > 0 ? 
                ConvertUserInputToLoanParameters(model) : new LoanParameters(_defaultLoanAmount, _defaultDurationOfLoan, _defaultAnnualInterestRate, _defaultInterestRatePeriod);

            var paymentOverview = danske.LoanDepartment.GeneratePaymentOverview(loanParameters);

            return new PaymentOverviewVM
            {
                AdministrationFee = paymentOverview.AdministrationFee.ToString("C", CultureInfo.CreateSpecificCulture("da-DK")),
                Duration = paymentOverview.Duration,
                LoanAmount = paymentOverview.LoanAmount.ToString("C", CultureInfo.CreateSpecificCulture("da-DK")),
                MonthlyPayment = paymentOverview.MonthlyPayment.ToString("C", CultureInfo.CreateSpecificCulture("da-DK")),
                TotalAmountPaidAsInterestRate = paymentOverview.TotalAmountPaidAsInterestRate.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))
            };
        }

        private LoanParameters ConvertUserInputToLoanParameters(GeneratePaymentOverviewQuery model)
        {
            string loanAmount = TryGetFromDictionary(model, LoanParametersDictionary.LOAN_AMOUNT, LoanParametersDictionary.LOAN_AMOUNT_SHORT);
            string duration = TryGetFromDictionary(model, LoanParametersDictionary.DURATION, LoanParametersDictionary.DURATION_SHORT);
            string annualInterestRate = TryGetFromDictionary(model, LoanParametersDictionary.ANNUAL_INTEREST_RATE, LoanParametersDictionary.ANNUAL_INTEREST_RATE_SHORT);
            string interestRatePeriod = TryGetFromDictionary(model, LoanParametersDictionary.INTEREST_RATE_PERIOD, LoanParametersDictionary.INTEREST_RATE_PERIOD_SHORT);

            return new LoanParameters(
                Convert.ToDecimal(loanAmount),
                Convert.ToInt32(duration),
                Convert.ToDouble(annualInterestRate, CultureInfo.InvariantCulture),
                Enum.Parse<InterestRatePeriod>(interestRatePeriod)
                );
        }

        private string TryGetFromDictionary(GeneratePaymentOverviewQuery model, string longParameterName, string shortParameterName)
        {
            string parameterValue = string.Empty;
            if(!model.LoanTerms.TryGetValue(longParameterName, out parameterValue))
            {
                model.LoanTerms.TryGetValue(shortParameterName, out parameterValue);
            }

            return parameterValue;
        }
    }
}
