using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteStateMachine
{
    class FiniteStateMachine : IState
    {
        public int LifeCount { get; private set; }
        public int CoinCount { get; private set; }
        public IState state;

        private SmallMario smallMario;
        private SuperMario superMario;
        private FireMario fireMario;
        private CapeMario capeMario;

        public FiniteStateMachine()
        {
            LifeCount = 1;
            CoinCount = 0;

            smallMario = new SmallMario(this);
            superMario = new SuperMario(this);
            fireMario = new FireMario(this);
            capeMario = new CapeMario(this);

            state = smallMario;
        }
        public IState GetState(string stateId)
        {
            switch (stateId)
            {
                case "smallMario":
                    return smallMario;
                case "superMario":
                    return superMario;
                case "fireMario":
                    return fireMario;
                case "capeMario":
                    return capeMario;
                default:
                    return null;
            }
        }
        public void GotMushroom()
        {
            state.GotMushroom();
        }
        public void GotFireFlower()
        {
            state.GotFireFlower();
        }
        public void GotFeather()
        {
            state.GotFeather();
        }
        public void GotCoins(int numberOfCoins)
        {
            Console.WriteLine($"Got {numberOfCoins} Coin(s)!");
            CoinCount += numberOfCoins;
            if (CoinCount >= 5000)
            {
                GotLife();
                CoinCount -= 5000;
            }
        }
        public void GotLife()
        {
            Console.WriteLine("Got Life!");
            LifeCount += 1;
        }
        public void LostLife()
        {
            Console.WriteLine("Lost Life!");
            LifeCount -= 1;
            if (LifeCount <= 0)
            {
                GameOver();
            }
        }
        public void MetMonster()
        {
            state.MetMonster();
        }
        public void GameOver()
        {
            LifeCount = 0;
            CoinCount = 0;
            Console.WriteLine("Game Over!");
        }
        public override string ToString()
        {
            return $"State: {state} | LifeCount: {LifeCount} | CoinsCount: {CoinCount} \n";
        }
    }

    class SmallMario : IState
    {
        private FiniteStateMachine fsm;
        public SmallMario(FiniteStateMachine fsm)
        {
            this.fsm = fsm;
        }
        public void GotMushroom()
        {
            Console.WriteLine("Got Mushroom!");
            fsm.state = fsm.GetState("superMario");
            fsm.GotCoins(100);
        }

        public void GotFireFlower()
        {
            Console.WriteLine("Got FireFlower!");
            fsm.state = fsm.GetState("fireMario");
            fsm.GotCoins(200);
        }

        public void GotFeather()
        {
            Console.WriteLine("Got Feather!");
            fsm.state = fsm.GetState("capeMario");
            fsm.GotCoins(300);
        }

        public void MetMonster()
        {
            Console.WriteLine("Met Monster!");
            fsm.state = fsm.GetState("smallMario");
            fsm.LostLife();
        }
    }

    class SuperMario : IState
    {
        private FiniteStateMachine fsm;
        public SuperMario(FiniteStateMachine fsm)
        {
            this.fsm = fsm;
        }
        public void GotMushroom()
        {
            Console.WriteLine("Got Mushroom");
            fsm.GotCoins(100);
        }
        public void GotFireFlower()
        {
            Console.WriteLine("Got FireFlower");
            fsm.state = fsm.GetState("fireMario");
            fsm.GotCoins(200);
        }
        public void GotFeather()
        {
            Console.WriteLine("Got Feather!");
            fsm.state = fsm.GetState("capeMario");
            fsm.GotCoins(300);
        }
        public void MetMonster()
        {
            Console.WriteLine("Met Monster!");
            fsm.state = fsm.GetState("smallMario");
        }
    }

    class FireMario : IState
    {
        private FiniteStateMachine fsm;
        public FireMario(FiniteStateMachine fsm)
        {
            this.fsm = fsm;
        }
        public void GotMushroom()
        {
            Console.WriteLine("Got Mushroom!");
            fsm.GotCoins(100);
        }
        public void GotFireFlower()
        {
            Console.WriteLine("Got FireFlower!");
            fsm.GotCoins(200);
        }
        public void GotFeather()
        {
            Console.WriteLine("Got Feather!");
            fsm.state = fsm.GetState("capeMario");
            fsm.GotCoins(300);
        }
        public void MetMonster()
        {
            Console.WriteLine("Met Monster!");
            fsm.state = fsm.GetState("smallMario");
        }

    }

    class CapeMario : IState
    {
        private FiniteStateMachine fsm;
        public CapeMario(FiniteStateMachine fsm)
        {
            this.fsm = fsm;
        }
        public void GotMushroom()
        {
            Console.WriteLine("Got Mushroom!");
            fsm.GotCoins(100);
        }
        public void GotFireFlower()
        {
            Console.WriteLine("Got FireFlower!");
            fsm.state = fsm.GetState("fireMario");
            fsm.GotCoins(200);
        }
        public void GotFeather()
        {
            Console.WriteLine("Got Feather!");
            fsm.GotCoins(300);
        }
        public void MetMonster()
        {
            Console.WriteLine("Met Monster!");
            fsm.state = fsm.GetState("smallMario");
        }
    }
}
