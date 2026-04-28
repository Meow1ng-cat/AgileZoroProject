using System.Text;
using Zoro.Entities;

namespace Zoro.Core
{
    public struct Cell
    {
        public char Ch;
        public ConsoleColor FgColor;
        public ConsoleColor BgColor;
        public int OccupiedEntityId;
    }
    static class RenderSystem
    {
        public static void Render(List<Entity> EntitiesToSpawn, Cell[,] framebuffer)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;

            ClearBuffer(framebuffer, ' ', ConsoleColor.Gray, ConsoleColor.Black);
            DrawMap(framebuffer);

            EntitiesToSpawn.Sort((a, b) => a.GetPos().Y.CompareTo(b.GetPos().Y));
            foreach (Entity entity in EntitiesToSpawn)
            {
                DrawEntity(framebuffer, entity);
            }
            DrawBuffer(framebuffer);
        } 
        private static void DrawMap(Cell[,] framebuffer)
        {
            for (int y = 0; y < 50; y++)
                for (int x = 0; x < 209; x++)
                {
                    framebuffer[y, x] = new Cell
                    {
                        Ch = ' ',
                        FgColor = ConsoleColor.Gray,
                        BgColor = ConsoleColor.Gray
                    };
                }
        }
        private static void DrawEntity(Cell[,] framebuffer, Entity entity)
        {
            string[] sprite = entity.GetSprite().SpriteImage;
            int x = entity.GetPos().X - entity.GetSprite().SpriteCenter.X,
                y = entity.GetPos().Y - entity.GetSprite().SpriteCenter.Y,
                id = entity.ID;

            for (int i = 0; i < sprite.Length; i++)
            {
                int screenY = y + i;
                if (screenY >= 50) continue;

                for (int j = 0; j < sprite[i].Length; j++)
                {
                    if (sprite[i][j] == ' ') continue;

                    if (framebuffer[screenY, x + j].OccupiedEntityId != id && framebuffer[screenY, x + j].OccupiedEntityId != 0)
                    {
                        int otherId = framebuffer[screenY, x + j].OccupiedEntityId;
                        Entity otherEntity = GameManager.Instance.GetEntityById(otherId);
                        entity.OnCollision(otherEntity);
                        otherEntity.OnCollision(entity);
                    }

                    framebuffer[screenY, x + j] = new Cell
                    {
                        Ch = sprite[i][j],
                        FgColor = entity.GetFgColor(),
                        BgColor = entity.GetBgColor(),
                        OccupiedEntityId = id
                    };
                }
            }
        }

        private static string GetColorEscape(ConsoleColor fg, ConsoleColor bg)
        {
            string fgCode = fg switch
            {
                ConsoleColor.Black => "\x1b[30m",
                ConsoleColor.Red => "\x1b[31m",
                ConsoleColor.Green => "\x1b[32m",
                ConsoleColor.Yellow => "\x1b[33m",
                ConsoleColor.Blue => "\x1b[34m",
                ConsoleColor.Magenta => "\x1b[35m",
                ConsoleColor.Cyan => "\x1b[36m",
                _ => "\x1b[37m"
            };

            string bgCode = bg switch
            {
                ConsoleColor.DarkRed => "\x1b[41m",  
                ConsoleColor.DarkGreen => "\x1b[42m",  
                ConsoleColor.DarkYellow => "\x1b[43m",  
                ConsoleColor.DarkBlue => "\x1b[44m",  
                ConsoleColor.DarkMagenta => "\x1b[45m",  
                ConsoleColor.DarkCyan => "\x1b[46m",  
                ConsoleColor.Gray => "\x1b[47m",
                _ => "" 
            };

            return fgCode + bgCode;
        }

        private static void DrawBuffer(Cell[,] framebuffer)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            StringBuilder line = new StringBuilder(209);
            ConsoleColor lastFg = ConsoleColor.White;
            ConsoleColor lastBg = ConsoleColor.Black;

            for (int y = 0; y < 50; y++)
            {
                line.Clear();

                for (int x = 0; x < 209; x++)
                {
                    Cell cell = framebuffer[y, x];
                    if (cell.FgColor != lastFg || cell.BgColor != lastBg)
                    {
                        line.Append(GetColorEscape(cell.FgColor, cell.BgColor));
                        lastFg = cell.FgColor;
                        lastBg = cell.BgColor;
                    }
                    line.Append(cell.Ch);
                }

                Console.WriteLine(line.ToString());
            }

            Console.ResetColor();
            Console.CursorVisible = true;
        }
        private static void ClearBuffer(Cell[,] framebuffer, char fillChar, ConsoleColor fg, ConsoleColor bg)
        {
            int height = framebuffer.GetLength(0);
            int width = framebuffer.GetLength(1);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    framebuffer[y, x] = new Cell
                    {
                        Ch = fillChar,
                        FgColor = fg,
                        BgColor = bg
                    };
        }
    }
}
