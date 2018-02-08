using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.ConsoleClient.Contracts
{
    public interface IConsoleHandle
    {
        void ClearCurrentLine();

        void HandleTabInput(StringBuilder builder, IEnumerable<string> data);

        void HandleKeyInput(StringBuilder builder, IEnumerable<string> data, ConsoleKeyInfo input);
    }
}
