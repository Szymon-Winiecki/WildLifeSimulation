using WildLifeSimulation.World;

namespace WildLifeSimulation.Animals
{
    class Lion : Predator
    {
        public Lion(Map map, Gender gender, Position position, int maxHp, Reporter reporter) : base(map, gender, position, maxHp, reporter) { }
    }
}
