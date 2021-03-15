using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteStateMachine
{
    class FiniteStateMachine
    {

        enum internalState
        {
            SmallMario,
            SuperMario,
            FireMario,
            CapMario
        }
        private internalState State { get; set; }
        public int LifeCount { get; private set; }
        public int CoinCount { get; private set; }

        public FiniteStateMachine()
        {
            LifeCount = 1;
            CoinCount = 0;
            State = internalState.SmallMario;
        }
        public void GotMushroom()
        {
            Console.WriteLine("Got Mushroom");
            if (State == internalState.SmallMario)
            {
                State = internalState.SuperMario;
            }
            GotCoins(100);
        }
        public void GotFireFlower()
        {
            Console.WriteLine("Got FireFlower!");
            State = internalState.FireMario;
            GotCoins(200);
        }
        public void GotFeather()
        {
            Console.WriteLine("Got Feather!");
            State = internalState.CapMario;
            GotCoins(300);
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
            Console.WriteLine("Met Monster!");
            if (State == internalState.SmallMario)
            {
                LostLife();
            }
            else
            {
                State = internalState.SmallMario;
            }
        }
        public void GameOver()
        {
            LifeCount = 0;
            CoinCount = 0;
            Console.WriteLine("Game Over!");
        }
        public override string ToString()
        {
            return $"State: {State} | LifeCount: {LifeCount} | CoinsCount: {CoinCount} \n";
        }
    }
}
