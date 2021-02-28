using SimpleBank.Application;
using SimpleBank.Application.Abstract;
using System;

namespace SimpleBank
{
    public static class RequestSender
    {
        public static T Send<T>(IRequest<T> request)
        {
            var handler = RequestsFactory.CreateRequestHandler(request);
            T result = default(T);
            try
            {
                result = handler.Handle();
            }
            catch (Exception e)
            {
                Manual.GenerateManual(e.Message);
            }

            return result;
        }
    }
}
