using System;
using System.Reflection.Metadata.Ecma335;

namespace SimpleBank.Application.Abstract
{
    public class ValidationResult
    {
        public bool IsSuccess { get; private set; }
        public void WithValidationMessage(string message)
        {
            if (!IsSuccess)
            {
                throw new InvalidOperationException(message);
            }
        }

        public ValidationResult Check(Func<bool> check)
        {
            IsSuccess = check();

            return this;
        }
    }
}
