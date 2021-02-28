using SimpleBank.Application.Abstract;
using System.Collections.Generic;

namespace SimpleBank.Application.Loans
{
    public class GeneratePaymentOverviewQuery : IRequest<PaymentOverviewVM>
    {
        public Dictionary<string, string> LoanTerms { get; set; }
    }
}
