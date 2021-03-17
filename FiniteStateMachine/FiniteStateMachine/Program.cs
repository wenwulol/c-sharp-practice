using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            FiniteStateMachine state = new FiniteStateMachine();
            Console.WriteLine(state);

            state.GotMushroom();
            Console.WriteLine(state);

            state.GotFireFlower();
            Console.WriteLine(state);

            state.GotFeather();
            Console.WriteLine(state);

            state.GotCoins(4800);
            Console.WriteLine(state);

            state.MetMonster();
            Console.WriteLine(state);

            state.MetMonster();
            Console.WriteLine(state);

            state.MetMonster();
            Console.WriteLine(state);

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
