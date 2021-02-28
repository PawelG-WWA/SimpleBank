using System;

namespace SimpleBank.Application.Abstract
{
    public interface IRequestHandler<T, Q>
    {
        Q Handle(T model);
    }
}
