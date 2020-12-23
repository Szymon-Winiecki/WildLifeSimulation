using System;
using System.Collections.Generic;
using System.Text;

namespace WildLifeSimulation.GameStates
{
    class EndGameState : GameState
    {
        public override GameState Main()
        {
            return this;
        }
    }
}
