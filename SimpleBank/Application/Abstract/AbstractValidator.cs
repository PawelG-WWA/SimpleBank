using System;

namespace SimpleBank.Application.Abstract
{
    public abstract class AbstractValidator<T> : IValidator<T>
    {
        public T Model { get; private set; }
        public ValidationResult Result { get; protected set; }
        public AbstractValidator()
        {
            Result = new ValidationResult();
        }

        public abstract void Validate(T argument);
        public void SetUp(T model)
        {
            Model = model;
        }
        public ValidationResult Check(Func<bool> check) => Result.Check(check);
    }
}
