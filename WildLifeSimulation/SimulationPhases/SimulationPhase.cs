using System;
using System.Collections.Generic;
using WildLifeSimulation.World;

namespace WildLifeSimulation.SimulationPhases
{
    abstract class SimulationPhase
    {
        protected Map map;

        public SimulationPhase(Map map)
        {
            this.map = map;
        }
        public abstract bool Main();
    }
}
