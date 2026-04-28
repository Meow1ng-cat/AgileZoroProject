namespace Zoro.Core
{
    public class GameMap
    {
        public readonly int Height;
        public readonly int Width;
        private Cell[,] FrameBuffer;

        public GameMap(int height, int width)
        {
            Height = height;
            Width = width;
            FrameBuffer = new Cell[Height, Width];
        }

        public Cell[,] GetFrameBuffer() { return FrameBuffer; }
    }

}
