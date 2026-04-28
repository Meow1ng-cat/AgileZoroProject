using Zoro.Core;

namespace Zoro.Entities.Units
{
    public class SwordsmanSpawner : UnitSpawner
    {
        public override Unit CreateUnit()
        {
            return new Swordsman(100, Direction.Right);
        }
    }

}
