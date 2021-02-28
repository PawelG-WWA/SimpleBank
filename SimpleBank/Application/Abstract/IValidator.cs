namespace SimpleBank.Application.Abstract
{
    public interface IValidatorMarkup { }

    public interface IValidator<T> : IValidatorMarkup
    {
        void Validate(T argument);
    }
}
