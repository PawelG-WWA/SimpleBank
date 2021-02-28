using SimpleBank.Application.Abstract;
using SimpleBank.Application.Loans;
using System;
using System.Collections.Generic;

namespace SimpleBank.Application
{
    public static class RequestsFactory
    {
        private static Dictionary<Type, Type> _requests = new Dictionary<Type, Type>();

        public static void Init()
        {
            _requests.Add(typeof(GeneratePaymentOverviewQuery), typeof(GeneratePaymentOverviewQueryHandler));
        }

        public static RequestHandlerBase<T> CreateRequestHandler<T>(IRequest<T> query)
        {
            var queryType = query.GetType();

            if (_requests[queryType] != null)
            {
                var handlerWrapper = (RequestHandlerBase<T>)Activator.CreateInstance(typeof(RequestHandlerWrapper<,>).MakeGenericType(queryType, typeof(T)));
                handlerWrapper.AddHandler(Activator.CreateInstance(_requests[queryType]));
                handlerWrapper.SetModel(query);
                return handlerWrapper;
            }

            throw new NotSupportedException($"Request for {typeof(T)} couldn't be found");
        }
    }
}
