using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.LogSaver
{
    public class LogSave : ILogSaveData
    {
        private IList<string> log;

        public LogSave(IList<string> log)
        {
            this.log = log;
        }

        public IList<string> GetGameLog => this.log;

        public void AddLog(string log)
        {
            this.log.Add(log);
        }
    }
}
