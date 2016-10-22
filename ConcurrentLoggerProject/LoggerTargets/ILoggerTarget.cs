using System.Threading.Tasks;

namespace ConcurrentLoggerProject
{
    interface ILoggerTarget
    {
        void Flush(Log log);
        Task<bool> FlushAsync();
        void Close();
    }
} 