using Syph_V02.Core.Components.Engine.Contracts;

namespace Syph_V02.Core.Components.Engine
{
    /// <summary>
    /// Syph V02 Engine
    /// </summary>
    public sealed class SyphEngine : IEngine
    {     
        private readonly IExecute executer;
        
        public SyphEngine(IExecute executer)
        {
            this.executer = executer;        
        }

        /// <summary>
        /// Start point of the engine.
        /// </summary>
        public void Start()
        {
            string displayProvider = "menu";

            executer.Execute(displayProvider);
        }
    }
}
