using System;
using System.Collections.Generic;
using System.Text;
using Zoro.Core;

namespace Zoro.Sprites
{
    internal class HealthBarSpriteSet : SpriteSet
    {
        private readonly Sprite FullHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
             {
            @"=========="
            }
        };
        public Sprite GetFullHPBar => FullHPBarSprite;

        private readonly Sprite NinetyHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
             {
            @"==========-"
            }
        };
        public Sprite GetNinetyHPBar => FullHPBarSprite;

        private readonly Sprite EightyHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
             {
            @"=========--"
            }
        };
        public Sprite GetEightyHPBar => EightyHPBarSprite;

        private readonly Sprite SeventyHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
       {
            @"========---"
        }
        };
        public Sprite GetSeventyHPBar => SeventyHPBarSprite;

        private readonly Sprite SixtyHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
            {
            @"=======----"
        }
        };
        public Sprite GetSixtyHPBar => SixtyHPBarSprite;

        private readonly Sprite FiftyHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
            {
            @"======-----"
        }
        };
        public Sprite GetFiftyHPBar => FiftyHPBarSprite;

        private readonly Sprite FortyHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
            {
            @"=====------"
        }
        };
        public Sprite GetFortyHPBar => FortyHPBarSprite;

        private readonly Sprite ThirtyHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
            {
            @"====-------"
        }
        };
        public Sprite GetThirtyHPBar => ThirtyHPBarSprite;

        private readonly Sprite TwentyHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
            {
            @"===--------"
        }
        };
        public Sprite GetTwentyHPBar => TwentyHPBarSprite;

        private readonly Sprite TenHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
            {
            @"==---------"
        }
        };
        public Sprite GetTenHPBar => TenHPBarSprite;

        private readonly Sprite ZeroHPBarSprite = new()
        {
            SpriteCenter = new Vector2d(7, 0),
            SpriteImage = new[]
            {
            @"=----------"
        }
        };
        public Sprite GetZeroHPBar => ZeroHPBarSprite;
    }
}
