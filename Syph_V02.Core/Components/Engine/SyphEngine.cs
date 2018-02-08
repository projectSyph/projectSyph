﻿using Syph_V02.Core.Components.Engine.Contracts;
using System;

namespace Syph_V02.Core.Components.Engine
{
    /// <summary>
    /// Syph V02 Engine
    /// </summary>
    public sealed class SyphEngine : IEngine
    {
        private readonly IRenderer renderer;

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
                    // DO somthing with commands
                    this.CommandsProcessor(currentCommandLine);
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
            return string.Empty;
        }
    }
}
