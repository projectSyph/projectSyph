using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.LogSaver
{
    public  interface ILogSaveData
    {
         IList<string> GetGameLog { get; }

        void AddLog(string log);
    }
}
