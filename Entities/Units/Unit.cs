using System.Numerics;
using Zoro.Core;
using Zoro.Entities.UI;
using Zoro.Sprites;

namespace Zoro.Entities.Units
{
    public enum UnitState
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }

    public abstract class Unit : Entity
    {
        private readonly UnitSpriteSet UnitSpriteSet;
        private float stateTimer = 0f;

        protected int Speed = 1;
        public bool IsAttacking = false;
        public int MaxHealth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public UnitState State { get; private set; } = UnitState.Idle;
        public Direction Direction { get; protected set; }

        public event Action<int> OnHealthChanged;

        public Unit(UnitSpriteSet spriteSet, int maxHealth, Direction direction) : base(spriteSet)
        {
            UnitSpriteSet = spriteSet;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            Direction = direction;
            Sprite = Direction == Direction.Right
                        ? UnitSpriteSet.GetIdleRight
                        : UnitSpriteSet.GetIdleLeft;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (CurrentHealth == 0) 
            {
                GameManager.Instance.UnregisterEntity(this);

            }

            if (stateTimer > 0)
            {
                stateTimer -= deltaTime;
                if (stateTimer <= 0) stateTimer = 0;
            }
            else if (stateTimer == 0)
            {
                IsAttacking = false;
                SetState(UnitState.Idle, 0f);
            }

            switch (State)
            {
                case UnitState.Idle:
                    Sprite = Direction == Direction.Right
                        ? UnitSpriteSet.GetIdleRight
                        : UnitSpriteSet.GetIdleLeft;
                    break;
                case UnitState.Moving:
                    if (Sprite.Equals(UnitSpriteSet.GetIdleRight) || Sprite.Equals(UnitSpriteSet.GetIdleLeft))
                    {
                        Sprite = Direction == Direction.Right
                        ? UnitSpriteSet.GetMoveRight
                        : UnitSpriteSet.GetMoveLeft;
                    }
                    else if (Sprite.Equals(UnitSpriteSet.GetMoveRight) || Sprite.Equals(UnitSpriteSet.GetMoveLeft))
                    {
                        Sprite = Direction == Direction.Right
                        ? UnitSpriteSet.GetIdleRight
                        : UnitSpriteSet.GetIdleLeft;
                    }
                    else
                    {
                        //Написать если будут логи
                    }
                    break;
                case UnitState.Attacking:
                    Sprite = Direction == Direction.Right
                        ? UnitSpriteSet.GetAttackRight
                        : UnitSpriteSet.GetAttackLeft;
                    break;
            }
        }

        public void SetState(UnitState newState, float duration = 0f)
        {
            State = newState;
            stateTimer = duration;
        }

        public void SpawnEntity(int posX, int posY, Direction direction)
        {
            GameManager.Instance.RegistrateEntity(this);
            SetPos(posX, posY);
            Direction = direction;
        }


        public void MoveUp()
        {
            if (State == UnitState.Idle || State == UnitState.Moving)
            {
                SetState(UnitState.Moving, 0.2f);
                SetPos(GetPos().X, GetPos().Y - Speed);
            }
        }
        public void MoveDown()
        {
            if (State == UnitState.Idle || State == UnitState.Moving)
            {
                SetState(UnitState.Moving, 0.2f);
                SetPos(GetPos().X, GetPos().Y + Speed);
            }
        }
        public void MoveRight()
        {
            if (State == UnitState.Idle || State == UnitState.Moving)
            {
                Direction = Direction.Right;
                SetState(UnitState.Moving, 0.2f);
                SetPos(GetPos().X + Speed, GetPos().Y);
            }
        }
        public void MoveLeft()
        {
            if (State == UnitState.Idle || State == UnitState.Moving)
            {
                Direction = Direction.Left;
                SetState(UnitState.Moving, 0.1f);
                SetPos(GetPos().X - Speed, GetPos().Y);
            }
        }

        public void Attack()
        {
            IsAttacking = true;
            SetState(UnitState.Attacking, 0.5f);
            if (Direction == Direction.Right)
            {
                SetPos(GetPos().X + Speed * 3, GetPos().Y);
            }
            else
            {
                SetPos(GetPos().X - Speed * 3, GetPos().Y);
            }
        }

        public void TakeDamage(int damageAmount) 
        { 
            CurrentHealth -= damageAmount;
            if(CurrentHealth < 0 ) { CurrentHealth = 0; }
            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }

}
