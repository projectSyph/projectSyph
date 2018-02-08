namespace Syph.CLI
{
    using Syph_V02.Core.Components.Engine;
    using Syph_V02.Core.Components.Engine.ConsoleClient;
    using System;

    public class Program
    {
        public static void Main()
        {

            var engine = new SyphEngine(new ConsoleRenderer());

            engine.Start();
        }
    }
}
