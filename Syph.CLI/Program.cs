namespace Syph.CLI
{
    using Autofac;
    using Syph.CLI.InjectionConfig;
    using Syph_V02.Core.Components.Engine;
    using Syph_V02.Core.Components.Engine.ConsoleClient;
    using Syph_V02.Core.Components.Engine.Contracts;
    using System;

    public class Program
    {
        public static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacConfig());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();

            //Just for test purposes
            //var engine = new SyphEngine(new ConsoleRenderer(), new CommandsFactory());

            //engine.Start();
        }
    }
}
