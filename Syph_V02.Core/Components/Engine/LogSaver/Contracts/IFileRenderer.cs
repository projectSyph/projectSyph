﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.LogSaver.Contracts
{
    public interface IFileRenderer
    {
        void WriteToFile(IEnumerable<string> info);
    }
}