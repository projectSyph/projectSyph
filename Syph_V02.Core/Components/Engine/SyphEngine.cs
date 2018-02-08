using Syph_V02.Core.Components.Engine.Contracts;
using System;
using System.Linq;

namespace Syph_V02.Core.Components.Engine
{
    /// <summary>
    /// Syph V02 Engine
    /// </summary>
    public sealed class SyphEngine : IEngine
    {
        private readonly IRenderer renderer;
        private readonly ICommandsFactory factory;

        /// <summary>
        /// Initialize fields
        /// </summary>
        public SyphEngine(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        /// <summary>
        /// Start point of the engine.
        /// </summary>
        public void Start()
        {
            try
            {
                foreach (var currentCommandLine in this.renderer.Input())
                {
                    // Testing
                    var testStartingCommand = this.CommandsProcessor(currentCommandLine);
                    this.renderer.Output(testStartingCommand);
                }
               
               
            }
            catch (Exception ex)
            {
                // Throw something .....   
                this.renderer.Output(ex.Message);
            }
        }

        private string CommandsProcessor(string currentCommandLine)
        {
            var command = currentCommandLine.Split(' ').ToList();

            var commandName = command[0];
            var commandParameters = command.Skip(1).ToList();

            var currentCommand = this.factory.GetCommand(commandName.ToLower());

            return currentCommand.Execute(commandParameters);
        }
    }
}
