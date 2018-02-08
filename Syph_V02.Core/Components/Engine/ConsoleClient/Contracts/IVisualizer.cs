using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syph_V02.Core.Components.Engine.Contracts
{
    public interface IVisualizer
    {      
        string ReadTextFile( string filenames, bool clear = true );
    }
}
