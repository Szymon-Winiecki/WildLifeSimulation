using WildLifeSimulation.GameStates;

namespace WildLifeSimulation
{
    class Game
    {
        private bool isRunning = false;
        private GameState actualGameState;

        public void Start()
        {
            if (isRunning)
            {
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
                actualGameState = actualGameState.Main();

                if(actualGameState.GetType() == GameState.endGame)
                {
                    isRunning = false;
                }
            }
        }
    }
}
