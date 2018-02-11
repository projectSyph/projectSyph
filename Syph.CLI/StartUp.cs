namespace Syph.CLI
{
    using Autofac;
    using Syph.CLI.InjectionConfig;
    using Syph_V02.Core.Components.Engine;
    using Syph_V02.Core.Components.Engine.ConsoleClient;
    using Syph_V02.Core.Components.Engine.Contracts;
    using System;

    public class StartUp
    {
        public static void Main()
        {
        //    //This is just for fun .. ignored !!
        //    Console.Title = "SYPH V02";
        //    Console.SetWindowSize(59, 26);
        //    Console.ForegroundColor = ConsoleColor.DarkCyan;
        //    Console.CursorSize = 30;
        //    //Console.SetBufferSize(60, 26);

            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacConfig());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();           
        }
    }
}
