using Zoro.Core;

namespace Zoro.Sprites
{
    public class RapierSpriteSet : WeaponSpriteSet
    {
        private readonly Sprite IdleRightSprite = new()
        {
            SpriteCenter = new Vector2d(0, 0),
            SpriteImage = new[]
                {
            @")——————"
            }
        };
        public override Sprite GetIdleRight => IdleRightSprite;
        public override Sprite GetMoveRight => IdleRightSprite;
        public override Sprite GetAttackRight => IdleRightSprite;

        private readonly Sprite IdleLeftSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
            {
            @"——————("
            }
        };
        public override Sprite GetIdleLeft => IdleLeftSprite;
        public override Sprite GetMoveLeft => IdleLeftSprite;
        public override Sprite GetAttackLeft => IdleLeftSprite;
    }

}
