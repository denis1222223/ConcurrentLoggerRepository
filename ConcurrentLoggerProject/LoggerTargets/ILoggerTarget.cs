using System.Threading.Tasks;

namespace ConcurrentLoggerProject
{
    public interface ILoggerTarget
    {
        void Flush(Log log);
        Task<bool> FlushAsync();
        void Close();
    }
} 