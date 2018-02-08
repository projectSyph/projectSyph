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
            //TODO GET THIS THINGS OUT OF HERE!!
            this.visuzlizer.ScreanRender("logo");
            this.visuzlizer.ScreanRender("menu");

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
