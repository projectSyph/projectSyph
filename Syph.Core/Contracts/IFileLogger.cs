using System;
using System.Collections.Generic;
using System.Text;

namespace Syph.Core.Contracts
{
    interface IFileLogger
    {
        void WriteLog(IList<string> log);
    }
}
