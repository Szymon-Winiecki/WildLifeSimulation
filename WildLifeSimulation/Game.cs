using System;
using WildLifeSimulation.GameStates;

namespace WildLifeSimulation
{
    class Game
    {
        public static readonly GameState EndGameState = new EndGameState();

        private bool isRunning = false;
        private GameState actualGameState;

        public void Start()
        {
            if (isRunning)
            {
                //add some error
                return;
            }

            isRunning = true;
            actualGameState = new MenuGameState();
            GameLoop();
        }

        private void GameLoop()
        {
            while (isRunning)
            {
                //invoke actualGameState main funtion

                if(actualGameState == Game.EndGameState)
                {
                    isRunning = false;
                }
            }
        }
    }
}
