using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.Contracts
{
    public interface IInputLineExecuter
    {
        void InputExecuter(string dirrection);

        string CommandsProcessor(string currentCommandLine);
    }
}
