using System.Reflection;
using Autofac;
using Syph_V02.Core.Components.Engine;
using Syph_V02.Core.Components.Engine.Contracts;
using Syph_V02.Core.Components.Engine.Factories;
using Syph_V02.Core.Components.Commands;
using Syph_V02.Core.Components.Commands.Contracts;
using Syph_V02.Core.Components.Engine.ConsoleClient;
using Syph_V02.Core.AppConfigurations.Constants;
using Syph_V02.Core.Components.Engine.GameManager.Factories;
using Syph_V02.Core.Components.Engine.GameManager.Contracts;
using Syph_V02.Core.Models;
using Syph_V02.Core.Models.Contracts;
using Syph_V02.Core.Components.Engine.LogSaver;
using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using Syph_V02.Core.Components.Engine.GameManager;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Contracts;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Commands;
using Syph_V02.Core.Components.Engine.GameManager.NewGameComponents.Constants;

namespace Syph.CLI.InjectionConfig
{
    public sealed class AutofacConfig : Autofac.Module
    {        
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.Load("Syph_V02.Core");

            builder.RegisterAssemblyTypes(currentAssembly).AsImplementedInterfaces();

            builder.RegisterType<SyphEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<ILExecuter>().As<IExecute>().SingleInstance();
            builder.RegisterType<IOConsoleSettings>().AsSelf().SingleInstance();
            builder.RegisterType<Constants>().AsSelf().SingleInstance();

            builder.RegisterType<PlayerFactory>().As<IPlayerFactory>().SingleInstance();
            builder.RegisterType<DataStore>().As<IDataStore>().SingleInstance();
            
            //builder.RegisterType<Player>().As<IPlayer>();

            builder.RegisterType<StartNewGame>().Named<ICommand>("new");
            builder.RegisterType<Menu>().Named<ICommand>("menu");
            builder.RegisterType<Guide>().Named<ICommand>("guide");
            builder.RegisterType<Credits>().Named<ICommand>("credits");
            builder.RegisterType<About>().Named<ICommand>("about");
            builder.RegisterType<HelpMenu>().Named<ICommand>("help");
            builder.RegisterType<ExitGame>().Named<ICommand>("exit");

            builder.RegisterType<BattleMenu>().Named<ICommand>("battleMenu");
            builder.RegisterType<Attack>().Named<ICommand>("attack");
            builder.RegisterType<BattleConstants>().AsSelf().SingleInstance();
            builder.RegisterType<BattleVisualizer>().As<IBattleVisualizer>().SingleInstance();

            builder.RegisterType<NewGame>().As<IGameManager>();
            builder.RegisterType<BattleField>().As<IBattleField>().SingleInstance();
            builder.RegisterType<BattleCalculator>().As<IBattleCalculator>().SingleInstance();
            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>().SingleInstance();
        }
    }
}
