using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Contracts
{
    interface ILogger
    {
        void WriteLog(string[] log);
    }
}
