using Syph_V02.Core.Components.Engine.LogSaver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.GameManager.Contracts
{
    public interface IGameManager
    {
        string ExecuteBattle(IDataStore data);
    }
}
