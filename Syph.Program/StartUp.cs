using System;
using System.Collections.Generic;
using Syph.Core;
using Syph.Core.Engine;

namespace Syph
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] r = { "pe6o attacked", "go6o died" };
            FileLogger a = new FileLogger();
            a.WriteLog(r);
            //SyphEngine.Instance.Start();
        }
    }
}
