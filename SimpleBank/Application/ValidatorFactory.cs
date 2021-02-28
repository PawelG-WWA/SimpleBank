using SimpleBank.Application.Abstract;
using SimpleBank.Application.Loans;
using System;
using System.Collections.Generic;

namespace SimpleBank.Application
{
    public static class ValidatorFactory
    {
        private static Dictionary<Type, Type> _validators = new Dictionary<Type, Type>();

        public static void Init()
        {
            _validators.Add(typeof(GeneratePaymentOverviewQuery), typeof(GeneratePaymentOverviewQueryValidator));
        }


        public static IValidator<T> CreateValidator<T>()
        {
            if (_validators[typeof(T)] != null)
            {
                return Activator.CreateInstance(_validators[typeof(T)]) as IValidator<T>;
            }

            throw new NotSupportedException($"Validator for {typeof(T)} couldn't be found");
        }
    }
}
