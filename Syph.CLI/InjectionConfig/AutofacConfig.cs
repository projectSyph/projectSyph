using System.Reflection;
using Autofac;
using Syph_V02.Core.Components.Engine;
using Syph_V02.Core.Components.Engine.Contracts;
using Syph_V02.Core.Components.Engine.Factories;
using Syph_V02.Core.Components.Commands;
using Syph_V02.Core.Components.Commands.Contracts;

namespace Syph.CLI.InjectionConfig
{
    public sealed class AutofacConfig : Autofac.Module
    {
        
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.Load("Syph_V02.Core");

            builder.RegisterAssemblyTypes(currentAssembly)
                .AsImplementedInterfaces();

            builder.RegisterType<SyphEngine>().As<IEngine>().SingleInstance();

           
            builder.RegisterType<StartNewGame>().Named<ICommand>("new");

            builder.RegisterType<Guide>().Named<ICommand>("guide");
            builder.RegisterType<Credits>().Named<ICommand>("credits");
            builder.RegisterType<About>().Named<ICommand>("about");
            builder.RegisterType<HelpMenu>().Named<ICommand>("help");

            builder.RegisterType<ExitGame>().Named<ICommand>("exit");

            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>().SingleInstance();
        }
    }
}
