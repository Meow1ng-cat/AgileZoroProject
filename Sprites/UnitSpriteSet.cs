namespace Zoro.Sprites
{
    public abstract class UnitSpriteSet : SpriteSet
    {
        public abstract Sprite GetIdleRight { get; }
        public abstract Sprite GetIdleLeft { get; }
        public abstract Sprite GetMoveRight { get; }
        public abstract Sprite GetMoveLeft { get; }
        public abstract Sprite GetAttackRight { get; }
        public abstract Sprite GetAttackLeft { get; }
    }
}
