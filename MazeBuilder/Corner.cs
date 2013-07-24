using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBuilder
{
    class Corner
    {
        public Corner(bool bottomIsUp, bool rightIsUp)
        {
            BottomIsUp = bottomIsUp;
            RightIsUp = rightIsUp;
        }

        public bool BottomIsUp { get; private set; }
        public bool RightIsUp { get; private set; }
    }
}
