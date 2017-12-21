using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Contracts
{
    interface IFileLogger
    {
        void Log(string msg);

        void WriteLog();
    }
}
