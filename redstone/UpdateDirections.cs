using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redstone
{
    [Flags]
    internal enum UpdateDirections
    {
        None=1, Left=2, Right=4, Up=8, Down=16
    }
}
