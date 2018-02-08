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

        private readonly IVisualizer visuzlizer;

        /// <summary>
        /// Initialize fields
        /// </summary>
        public SyphEngine(IRenderer renderer, ICommandsFactory factory, IVisualizer visuzlizer)
        {
            this.renderer = renderer;
            this.factory = factory;
            this.visuzlizer = visuzlizer;
        }

        /// <summary>
        /// Start point of the engine.
        /// </summary>
        public void Start()
        {
            //TODO: Find bether way to do this action -> print menu !!
            var firstRunMessage = this.visuzlizer.ReadTextFile("menu");
            renderer.Output(firstRunMessage);

            try
            {
              
                foreach (var currentCommandLine in this.renderer.Input())
                {
                   
                    var testStartingCommand = this.CommandsProcessor(currentCommandLine);
                    
                }
                              
            }
            catch (Exception ex)
            {
                this.renderer.Output(ex.Message);
            }
           
        }

        private string CommandsProcessor(string currentCommandLine)
        {
            var command = currentCommandLine.Split(' ').ToList();

            //Main command link
            var commandName = command[0];

            //Command parameters
            var commandParameters = command.Skip(1).ToList();

            //Action on current command
            var currentCommand = this.factory.GetCommand(commandName.ToLower());

            //Print command descripsion on console
            var message = this.visuzlizer.ReadTextFile(commandName);
            renderer.Output(message);

            return currentCommand.Execute(commandParameters);
        }
    }
}
