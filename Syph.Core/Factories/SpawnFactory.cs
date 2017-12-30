using Syph.Core.Contracts;
using Syph.Core.Models;

namespace Syph.Core.Factories
{
    public static class SpawnFactory
    {
        public static ISpawn CreateJuniorSpawn(string name, int souls)
        {
            return new JuniorSpawn(name, souls);
        }

        public static ISpawn CreateRegularSpawn(string name, int souls)
        {
            return new RegularSpawn(name, souls);
        }

        public static ISpawn CreateSeniorSpawn(string name, int souls)
        {
            return new SeniorSpawn(name, souls);
        }
    }
}
