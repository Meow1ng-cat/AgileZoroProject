
using Zoro.Core;
using Zoro.Entities.Units;
using Zoro.Sprites;

namespace Zoro.Entities.UI
{
    internal class HealthBar : Entity
    {
        private readonly HealthBarSpriteSet HealthBarSpriteSet;
        public HealthBar() : base(new HealthBarSpriteSet())
        {
            HealthBarSpriteSet = new HealthBarSpriteSet();
            Sprite = HealthBarSpriteSet.GetFullHPBar;
        }
        private Unit WatchedUnit;

        public void Subscribe(Unit unit)
        {
            WatchedUnit = unit;
            pos.X = WatchedUnit.GetPos().X;
            pos.Y = WatchedUnit.GetPos().Y - 1;
            WatchedUnit.OnHealthChanged += OnHeroHealthChanged;
        }

        public void Unsubscribe()
        {
            if (WatchedUnit != null)
            {
                WatchedUnit.OnHealthChanged -= OnHeroHealthChanged;
                WatchedUnit = null;
            }
        }

        public override void Update(float deltaTime)
        {
            pos.X = WatchedUnit.GetPos().X - WatchedUnit.GetSprite().SpriteCenter.X + Sprite.SpriteCenter.X;
            pos.Y = WatchedUnit.GetPos().Y - 2;
        }

        private void OnHeroHealthChanged(int newHealth)
        {
            switch ((int)(((float)WatchedUnit.CurrentHealth / (float)WatchedUnit.MaxHealth) * 10)) 
            {
                case 10:
                    Sprite = HealthBarSpriteSet.GetFullHPBar;
                    break;
                case 9:
                    Sprite = HealthBarSpriteSet.GetNinetyHPBar;
                    break;
                case 8:
                    Sprite = HealthBarSpriteSet.GetEightyHPBar;
                    break;
                case 7:
                    Sprite = HealthBarSpriteSet.GetSeventyHPBar;
                    break;
                case 6:
                    Sprite = HealthBarSpriteSet.GetSixtyHPBar;
                    break;
                case 5:
                    Sprite = HealthBarSpriteSet.GetFiftyHPBar;
                    break;
                case 4:
                    Sprite = HealthBarSpriteSet.GetFortyHPBar;
                    break;
                case 3:
                    Sprite = HealthBarSpriteSet.GetThirtyHPBar;
                    break;
                case 2:
                    Sprite = HealthBarSpriteSet.GetTwentyHPBar;
                    break;
                case 1:
                    Sprite = HealthBarSpriteSet.GetTenHPBar;
                    break;
                case 0:
                    Sprite = HealthBarSpriteSet.GetZeroHPBar;
                    break;
            }
        }
    }
}
