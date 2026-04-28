using Zoro.Core;
using Zoro.Sprites;

namespace Zoro.Entities
{
    public abstract class Entity
    {
        public int ID { get; protected set; } = NextID++;
        protected static int NextID = 1;

        protected SpriteSet SpriteSet;
        protected Sprite Sprite;

        protected ConsoleColor FgColor = ConsoleColor.Black;
        protected ConsoleColor BgColor = ConsoleColor.Black;

        protected Vector2d pos;
        protected Entity(SpriteSet spriteSet)
        {
            SpriteSet = spriteSet;
        }

        public virtual void Update(float dt)
        {
        }
        public void SpawnEntity()
        {
            GameManager.Instance.RegistrateEntity(this);
        }
        public void SpawnEntity(int posX , int posY)
        {
            GameManager.Instance.RegistrateEntity(this);
            SetPos(posX, posY);
        }

        public void SetPos(int x, int y)
        {
            pos.X = x; pos.Y = y;
        }
        public Vector2d GetPos() { return pos; }

        public virtual void OnCollision(Entity other) { }

        public SpriteSet GetSpriteSet() { return SpriteSet; }
        public void SetSprite(Sprite NewSprite) { Sprite = NewSprite; }

        public ConsoleColor GetFgColor() { return FgColor; }
        public void SetFgColor(ConsoleColor NewColor) { FgColor = NewColor; }
        public ConsoleColor GetBgColor() { return BgColor; }
        public void SetBgColor(ConsoleColor NewColor) { BgColor = NewColor; }
        public Sprite GetSprite() { return Sprite; }

    }
}
