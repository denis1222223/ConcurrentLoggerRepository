using System.Threading.Tasks;

namespace ConcurrentLoggerProject
{
    interface ILoggerTarget
    {
        bool Flush();
        Task<bool> FlushAsync();
    }
}