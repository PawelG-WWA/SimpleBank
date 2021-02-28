using System;

namespace SimpleBank.Application
{
    public static class Manual
    {
        public static void GenerateManual(string additionalMessage = "")
        {
            Console.WriteLine(
additionalMessage + 
@"
Available options:
--LoanAmount -la             Describes the amount of a laon in kr., e.g. 500000 (default)
--Duration -d                Describes a duration of a loan in years, e.g. 10 (default)
--AnnualInterestRate -air    Describes annual interest rate in percetanges, e.g. 5 or 5.5 (default)
--InterestRatePeriod -irp    Describes interest reate period, available values: Weekly, Monthly Quarterly (default: Monthly)

Examples:
.\SimpleBank.exe - this will run the program with default values
.\SimpleBank.exe --LoanAmount 300000 --Duration 15 --AnnualInterestRate 7 --InterestRatePeriod Monthly");
        }
    }
}
