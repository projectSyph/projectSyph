using Syph_V02.Core.Components.Engine.Contracts;
using Syph_V02.Core.Components.Engine.LogSaver;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine
{
    public class ILExecutor : IInputLineExecuter
    {
        private readonly IRenderer renderer;
        private readonly ICommandsFactory factory;
        private readonly IFileRenderer fileRenderer;

       private readonly ILogSaveData savedData;

        private readonly IVisualizer visuzlizer;

        public ILExecutor(IRenderer renderer, 
            ICommandsFactory factory, 
            IVisualizer visuzlizer, 
            IFileRenderer fileRenderer,
            ILogSaveData savedData)
        {
            this.renderer = renderer;
            this.factory = factory;
            this.visuzlizer = visuzlizer;
            this.fileRenderer = fileRenderer;
            this.savedData = savedData;
        }

        public void InputExecuter(string dirrection)
        {
            //TODO: Find bether way to do this action -> print menu !!
            var firstRunMessage = this.visuzlizer.ReadTextFile(dirrection);
            renderer.Output(firstRunMessage);

            try
            {

                foreach (var currentCommandLine in this.renderer.Input())
                {

                    var testStartingCommand = this.CommandsProcessor(currentCommandLine);

                    savedData.AddLog(testStartingCommand);

                    //renderer.Output(testStartingCommand);

                }

            }
            catch (Exception ex)
            {
                this.renderer.Output(ex.Message);
            }

            renderer.Output("Strange but this is OUTOSAVE LOG... CHANGE ME!");
            fileRenderer.WriteToFile(savedData.GetGameLog);
        }

        public string CommandsProcessor(string currentCommandLine)
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
