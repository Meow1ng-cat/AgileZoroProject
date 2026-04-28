using Zoro.Entities;
using Zoro.Entities.UI;
using Zoro.Entities.Units;
using Zoro.Entities.Weapons;

namespace Zoro.Core
{
    public struct Vector2d
    {
        public int X, Y;
        public Vector2d(int x, int y) { X = x; Y = y; }
    }

    public enum Direction
    {
        Left,
        Right
    }

    public class GameEngineFacade()
    {
        static public void StartGame(GameMap GameMap, PlayerController PlayerController)
        {
            Thread renderThread = new(() =>
            {
                Cell[,] FrameBuffer = GameMap.GetFrameBuffer();
                while (true)
                {
                    List<Entity> Entities = GameManager.Instance.GetEntities().Values.ToList();
                    RenderSystem.Render(Entities, FrameBuffer);
                }
            });
            renderThread.Start();

            Thread logicThread = new(() =>
            {
                while (true)
                {
                    GameManager.Instance.Update();
                }
            });
            logicThread.Start();


            Thread inputThread = new(() =>
            {
                while (true)
                {
                    PlayerController.HandleInput();
                }
            });
            inputThread.Start();

        }

        static public void TestPatterns(GameMap GameMap, PlayerController PlayerController)
        {
            PlayerChar PlayerChar = new PlayerChar(100, Direction.Right);
            PlayerChar.SpawnEntity(20, 20);
            PlayerController.SetPlayerChar(PlayerChar);

            var HpBar = new HealthBar();
            HpBar.SpawnEntity(20, 20);
            HpBar.Subscribe(PlayerChar);

            Rapier PlayerRapier = new Rapier(25, Direction.Right, PlayerChar);
            PlayerRapier.SpawnEntity();


            UnitSpawner EnemySpawner = new SwordsmanSpawner();
            EnemySpawner.SpawnUnit(150, 20, Direction.Left);

            Swordsman original = new Swordsman(100, Direction.Right);
            original.SpawnEntity(150, 40, Direction.Right);

            var HpBarOriginal = new HealthBar();
            HpBarOriginal.SpawnEntity(20, 20);
            HpBarOriginal.Subscribe(original);

            Swordsman clone = (Swordsman)original.Clone();
            for (int i = 0; i < 100; i++)
            {
                clone.MoveLeft();
            }

            for (int i = 0; i < 20; i++)
            {
                original.MoveRight();
            }
        }
    }
}
