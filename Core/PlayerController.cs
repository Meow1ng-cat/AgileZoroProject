using Zoro.Entities.Units;

namespace Zoro.Core
{
    public class PlayerController
    {
        protected PlayerChar PlayerChar;

        public void SetPlayerChar(PlayerChar playerChar) { PlayerChar = playerChar; }
        public void HandleInput() 
        {
            if (Console.KeyAvailable && PlayerChar != null)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.W)
                    PlayerChar.MoveUp();
                if (key == ConsoleKey.A)
                    PlayerChar.MoveLeft();
                if (key == ConsoleKey.S)
                    PlayerChar.MoveDown();
                if (key == ConsoleKey.D)
                    PlayerChar.MoveRight();
                if (key == ConsoleKey.J)
                    PlayerChar.Attack();
            }
        }
    }
}
