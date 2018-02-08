using Syph_V02.Core.Components.Commands.Contracts;

namespace Syph_V02.Core.Components.Engine.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}
