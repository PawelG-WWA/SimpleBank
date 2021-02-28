using SimpleBank.Application;
using SimpleBank.Application.Loans;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SimpleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Start.SetUp();
            if (IsHelpNeeded(args))
            {
                Manual.GenerateManual();
            }
            else
            {
                var argumentsConvertedToDictionary = ConvertArgumentsToDictionary(args);


                var generateOverviewQueryResult = RequestSender.Send(new GeneratePaymentOverviewQuery
                {
                    LoanTerms = argumentsConvertedToDictionary
                });

                Console.WriteLine(generateOverviewQueryResult);
            }
        }

        private static Dictionary<string, string> ConvertArgumentsToDictionary(string[] args)
        {
            var dict = new Dictionary<string, string>();
            if (args.Length >= 2)
            {
                for (int i = 0; i < args.Length / 2; i++)
                {
                    dict.Add(args[i * 2], args[(i * 2) + 1]);
                }
            }

            return dict;
        }

        private static bool IsHelpNeeded(string[] args)
        {
            return args.Length == 1 && (args[0] == "-m" || args[0] == "--help");
        }
    }
}
