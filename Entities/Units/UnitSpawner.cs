using Zoro.Core;

namespace Zoro.Entities.Units
{
    public abstract class UnitSpawner
    {
        public void SpawnUnit(int posX, int posY)
        {
            Unit Unit = CreateUnit();
            Unit.SpawnEntity(posX, posY); 
        }
        public void SpawnUnit(int posX, int posY, Direction direction)
        {
            Unit Unit = CreateUnit();
            Unit.SpawnEntity(posX, posY, direction);
        }
        public abstract Unit CreateUnit();
    }
}
