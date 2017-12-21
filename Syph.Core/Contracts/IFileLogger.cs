namespace Syph.Core.Contracts
{
    interface IFileLogger
    {
        void Log(string msg);

        void WriteLog();
    }
}
