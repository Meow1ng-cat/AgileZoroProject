using Zoro.Core;

namespace Zoro.Sprites
{
    public class PlayerSpriteSet : UnitSpriteSet
    {
        private readonly Sprite IdleRightSprite = new()
        {
            SpriteCenter = new Vector2d(3, 1),
            SpriteImage = new[]
                {
            @"   O}     ",
            @" /[|]\\==o",
            @"/ |||     ",
            @" /   \    ",
            @"/     |   "
            },
            Sockets = new Dictionary<string, Vector2d>
            {
                ["WeaponSocket"] = new Vector2d(7, 0),
            }.AsReadOnly()
        };
        public override Sprite GetIdleRight => IdleRightSprite;
        //==================================================================
        private readonly Sprite IdleLefttSprite = new()
        {
            SpriteCenter = new Vector2d(6, 1),
            SpriteImage = new[]
               {
            @"     {O   ",
            @"o==//[|]\ ",
            @"     ||| \",
            @"    /   \ ",
            @"   |     \"
            },
            Sockets = new Dictionary<string, Vector2d>
            {
                ["WeaponSocket"] = new Vector2d(-6, 0),
            }.AsReadOnly()
        };
        public override Sprite GetIdleLeft => IdleLefttSprite;
        //==================================================================
        private readonly Sprite MoveRightSprite = new()
        {
            SpriteCenter = new Vector2d(3, 1),
            SpriteImage = new[]
                {
            @"   O}     ",
            @" /[|]\\==o",
            @"/ |||     ",
            @" /   \    ",
            @" |    \   "
            },
            Sockets = new Dictionary<string, Vector2d>
            {
                ["WeaponSocket"] = new Vector2d(7, 0),
            }.AsReadOnly()
        };
        public override Sprite GetMoveRight => MoveRightSprite;
        //==================================================================
        private readonly Sprite MoveLeftSprite = new()
        {
            SpriteCenter = new Vector2d(6, 1),
            SpriteImage = new[]
                {
            @"     {O   ",
            @"o==//[|]\ ",
            @"     ||| \",
            @"    /   \ ",
            @"   /     |"
            },
            Sockets = new Dictionary<string, Vector2d>
            {
                ["WeaponSocket"] = new Vector2d(-6, 0),
            }.AsReadOnly()
        };
        public override Sprite GetMoveLeft => MoveLeftSprite;
        //==================================================================
        private readonly Sprite AttackRightSprite = new()
        {
            SpriteCenter = new Vector2d(3, 1),
            SpriteImage = new[]
                 {
            @"   O}     ",
            @" /[|]=====o",
            @"/ |||     ",
            @" /   \    ",
            @"/    /    "
            },
            Sockets = new Dictionary<string, Vector2d>
            {
                ["WeaponSocket"] = new Vector2d(8, 0),
            }.AsReadOnly()
        };
        public override Sprite GetAttackRight => AttackRightSprite;
        //==================================================================
        private readonly Sprite AttackLeftSprite = new()
        {
            SpriteCenter = new Vector2d(7, 1),
            SpriteImage = new[]
                {
            @"      {O   ",
            @"o=====[|]\ ",
            @"      ||| \",
            @"     /   \ ",
            @"     \    \"
            },
            Sockets = new Dictionary<string, Vector2d>
            {
                ["WeaponSocket"] = new Vector2d(-7, 0),
            }.AsReadOnly()
        };
        public override Sprite GetAttackLeft => AttackLeftSprite;
        //==================================================================

        //public override string[] AttackLeft => new[]
        //{
        //    @"            {O   ",
        //    @"——————(o====[|]\ ",
        //    @"            ||| \",
        //    @"           /   \ ",
        //    @"           \    \"
        //};
        public string[] DefenseRight => new[]
        {
        @"          / ",
        @"   O}    /  ",
        @" /[|]\\ ⏜/   ",
        @"/ ||| \/    ",
        @" /   \      ",
        @"/     |     "
    };
        public string[] DefenseLeft => new[]
       {
        @" \          ",
        @"  \    {O   ",
        @"   \⏜ //[|]\ ",
        @"    \/ ||| \",
        @"      /   \ ",
        @"     |     \"
    };
        //public override string[] AttackRight => new[]
        //{
        //    @"   O}            ",
        //    @" /[|]====o)——————",
        //    @"/ |||            ",
        //    @" /   \           ",
        //    @"/    /           "
        //};
    }

}
