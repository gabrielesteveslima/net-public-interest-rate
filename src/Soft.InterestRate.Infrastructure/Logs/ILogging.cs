namespace Soft.InterestRate.Infrastructure.Logs
{
    public interface ILogging
    {
        void Error(object message);
        void Warning(object message);
        void Information(object message);
    }
}