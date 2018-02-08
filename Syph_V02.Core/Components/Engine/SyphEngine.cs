using Syph_V02.Core.Components.Engine.Contracts;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using System;
using System.Collections.Generic;
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
        private readonly IFileRenderer fileRenderer;

        private readonly IVisualizer visuzlizer;

        /// <summary>
        /// Initialize fields
        /// </summary>
        public SyphEngine(IRenderer renderer, ICommandsFactory factory, IVisualizer visuzlizer, IFileRenderer fileRenderer)
        {
            this.renderer = renderer;
            this.factory = factory;
            this.visuzlizer = visuzlizer;
            this.fileRenderer= fileRenderer;
            
        }

        /// <summary>
        /// Start point of the engine.
        /// </summary>
        public void Start()
        {
            //TODO: Find bether way to do this action -> print menu !!
            var firstRunMessage = this.visuzlizer.ReadTextFile("menu");
            renderer.Output(firstRunMessage);

            var safeLogg = new List<string>();

            try
            {
              
                foreach (var currentCommandLine in this.renderer.Input())
                {
                   
                    var testStartingCommand = this.CommandsProcessor(currentCommandLine);

                    safeLogg.Add(testStartingCommand);
                    renderer.Output(testStartingCommand);

                    //Testing new functionality Save to File
                    if (testStartingCommand == "exit")
                    {
                        fileRenderer.WriteToFile(safeLogg);
                    }
                    else
                    {
                        Console.WriteLine("ELSE");
                    }
                    
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
