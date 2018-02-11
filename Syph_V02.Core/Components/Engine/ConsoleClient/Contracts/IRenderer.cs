using System.Collections.Generic;

namespace Syph_V02.Core.Components.Engine.Contracts
{
    public interface IRenderer
    {
        IEnumerable<string> Input();

        void Output(string output);

        string LineReader();

        void SameLineOutput(string output);

    }
}
