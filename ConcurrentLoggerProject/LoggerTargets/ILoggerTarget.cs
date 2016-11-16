using System.Threading.Tasks;

namespace ConcurrentLoggerProject
{
    public interface ILoggerTarget
    {
        bool Flush(Log log);
        Task<bool> FlushAsync(Log log);
        void Close();
    }
} 