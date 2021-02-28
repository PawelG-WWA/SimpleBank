using System;
using System.Collections.Generic;

namespace SimpleBank.Application.Loans
{
    public static class LoanParametersDictionary
    {
        public const string LOAN_AMOUNT = "--LoanAmount";
        public const string LOAN_AMOUNT_SHORT = "-la";
        public const string DURATION = "--Duration";
        public const string DURATION_SHORT = "-d";
        public const string ANNUAL_INTEREST_RATE = "--AnnualInterestRate";
        public const string ANNUAL_INTEREST_RATE_SHORT = "-air";
        public const string INTEREST_RATE_PERIOD = "--InterestRatePeriod";
        public const string INTEREST_RATE_PERIOD_SHORT = "--irp";

        public static Dictionary<string, Type> Options { get; private set; } = new Dictionary<string, Type>()
        {
            { LOAN_AMOUNT, typeof(decimal) },
            { DURATION, typeof(int) },
            { ANNUAL_INTEREST_RATE,  typeof(double) },
            { INTEREST_RATE_PERIOD, typeof(string) },
            { LOAN_AMOUNT_SHORT, typeof(decimal) },
            { DURATION_SHORT, typeof(int) },
            { ANNUAL_INTEREST_RATE_SHORT, typeof(double) },
            { INTEREST_RATE_PERIOD_SHORT, typeof(string) }
        };
    }
}
