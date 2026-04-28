using Zoro.Entities;

namespace Zoro.Core 
{ 
    public class GameManager
    {
        private static GameManager _instance;
        private Dictionary<int, Entity> Entities = new();
        private DateTime lastFrame = DateTime.Now;
        private float deltaTime;

        private GameManager() { }
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }

        public void Update()
        {
            DateTime now = DateTime.Now;
            deltaTime = (float)(now - lastFrame).TotalSeconds; 
            lastFrame = now;


            foreach (Entity entity in Entities.Values.ToList().Where(e => e != null))
            {
                entity.Update(deltaTime);
            }
        }

        public void RegistrateEntity(Entity entity) 
        {
            Entities[entity.ID] = entity;
        }

        public void UnregisterEntity(Entity entity)
        {
            Entities.Remove(entity.ID);

            if (entity is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        public Dictionary<int, Entity> GetEntities() { return Entities; }
        public Entity GetEntityById(int id) { return Entities[id]; }
    }

}
