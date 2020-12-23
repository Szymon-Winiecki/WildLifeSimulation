using System;
using System.Collections.Generic;
using System.Text;

namespace WildLifeSimulation.GameStates
{
    abstract class GameState
    {
        public static readonly Type endGame = typeof(EndGameState);
        public abstract GameState Main();

    }
}
