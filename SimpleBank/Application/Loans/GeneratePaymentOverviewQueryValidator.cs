using SimpleBank.Application.Abstract;
using SimpleBank.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SimpleBank.Application.Loans
{
    public class GeneratePaymentOverviewQueryValidator : AbstractValidator<GeneratePaymentOverviewQuery>
    {
        public override void Validate(GeneratePaymentOverviewQuery argument)
        {
            SetUp(argument);

            HasAnyParameter(argument, () =>
            {
                foreach (var parameter in argument.LoanTerms)
                {
                    HasParameter(parameter.Key).WithValidationMessage($"Unknown key: {parameter.Key}");

                    if (parameter.Key != LoanParametersDictionary.INTEREST_RATE_PERIOD && parameter.Key != LoanParametersDictionary.INTEREST_RATE_PERIOD_SHORT)
                    {
                        HasCorrectValue(parameter).WithValidationMessage($"Invalid value for {parameter.Key} : {parameter.Value}");
                    }
                    else
                    {
                        IsInterestRatePeriodCorrect(parameter).WithValidationMessage($"Invalid interest rate period");
                    }
                }
            });
        }

        private void HasAnyParameter(GeneratePaymentOverviewQuery model, Action action)
        {
            if(model.LoanTerms.Count > 0)
            {
                action();
            }
        }

        public ValidationResult HasParameter(string key)
        {
            return Check(() => LoanParametersDictionary.Options.ContainsKey(key));
        }

        public ValidationResult HasCorrectValue(KeyValuePair<string, string> parameter)
        {
            var typeToCast = LoanParametersDictionary.Options[parameter.Key];

            return Check(() => Convert.ChangeType(parameter.Value, typeToCast, CultureInfo.InvariantCulture) != null);
        }

        public ValidationResult IsInterestRatePeriodCorrect(KeyValuePair<string, string> parameter)
        {
            return Check(() => Enum.TryParse(parameter.Value, out InterestRatePeriod interestRatePeriod));
        }
    }
}
