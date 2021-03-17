using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteStateMachine
{
    interface IState
    {
        void GotMushroom();
        void GotFireFlower();
        void GotFeather();
        void MetMonster();
    }
}
