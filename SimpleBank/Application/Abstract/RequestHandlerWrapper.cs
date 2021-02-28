using System;

namespace SimpleBank.Application.Abstract
{
    public abstract class RequestHandlerBase<TResponse>
    {
        public abstract void AddHandler<U>(U handler);
        public abstract TResponse Handle();
        public abstract void SetModel(object model);
    }

    public class RequestHandlerWrapper<T, Q> : RequestHandlerBase<Q>
    {
        public IRequestHandler<T, Q> Handler { get; private set; }
        public T Model { get; private set; }

        public override void AddHandler<U>(U handler)
        {
            Handler = (IRequestHandler<T,Q>)handler;
        }

        public override void SetModel(object model)
        {
            Model = (T)model;
        }

        public override Q Handle()
        {
            return Handler.Handle(Model);
        }
    }
}
