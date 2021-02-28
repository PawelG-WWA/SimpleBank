using NUnit.Framework;
using SimpleBank.Application;
using SimpleBank.Application.Loans;
using System.Collections.Generic;

namespace SimpleBank.Tests
{
    public class PaymentOverviewTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PaymentOverviewForDefaultValues()
        {
            var emptyDictionary = new Dictionary<string, string>();

            var result = new GeneratePaymentOverviewQueryHandler().Handle(new GeneratePaymentOverviewQuery
            {
                LoanTerms = emptyDictionary
            });

            Assert.AreEqual("500.000,00 kr.", result.LoanAmount);
            Assert.AreEqual(10, result.Duration);
            Assert.AreEqual("5.303,28 kr.", result.MonthlyPayment);
            Assert.AreEqual("136.393,09 kr.", result.TotalAmountPaidAsInterestRate);
            Assert.AreEqual("5.000,00 kr.", result.AdministrationFee);
        }

        [Test]
        public void PaymentOverviewForValidParameters()
        {
            var loanTerms = new Dictionary<string, string>
            {
                { "--LoanAmount", "100000"},
                { "--Duration", "15"},
                { "--AnnualInterestRate", "4.5"},
                { "--InterestRatePeriod", "Monthly"}
            };

            var result = new GeneratePaymentOverviewQueryHandler().Handle(new GeneratePaymentOverviewQuery
            {
                LoanTerms = loanTerms
            });

            Assert.AreEqual("100.000,00 kr.", result.LoanAmount);
            Assert.AreEqual(15, result.Duration);
            Assert.AreEqual("764,99 kr.", result.MonthlyPayment);
            Assert.AreEqual("37.698,79 kr.", result.TotalAmountPaidAsInterestRate);
            Assert.AreEqual("1.000,00 kr.", result.AdministrationFee);
        }
    }
}