using SimpleBank.Application;

namespace SimpleBank
{
    public static class Start
    {
        public static void SetUp()
        {
            ValidatorFactory.Init();
            RequestsFactory.Init();
        }
    }
}
