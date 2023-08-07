using UnityEngine.Events;

namespace Globals
{
    public class ThirdLevelEveneManager
    {
        public UnityEvent OnSpawnEnemy = new();
        public UnityEvent OnDieEnemy = new();
        public UnityEvent OnEndSpawn = new();

        private static ThirdLevelEveneManager _singleton;
        public static ThirdLevelEveneManager Instance()
        {
            return _singleton ??= new ThirdLevelEveneManager();
        }
        public void SendEndSpawnSignal()
        {
            OnEndSpawn.Invoke();
        }
        public void SendSpawnEnemySignal()
        {
            OnSpawnEnemy.Invoke();
        }
        
        public void SendDieEnemySignal()
        {
            OnDieEnemy.Invoke();
        }
    }
}