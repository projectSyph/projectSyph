using Autofac;
using Syph_V02.Core.Components.Commands.Contracts;
using Syph_V02.Core.Components.Engine.Contracts;

namespace Syph_V02.Core.Components.Engine.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IComponentContext container;

        public CommandsFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.container.ResolveNamed<ICommand>(commandName);
        }
    }
}
