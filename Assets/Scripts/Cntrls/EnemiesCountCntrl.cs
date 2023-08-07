using Globals;
using UnityEngine;
using UnityEngine.Events;

namespace Cntrls
{
    public class EnemiesCountCntrl : MonoBehaviour
    {
        [SerializeField] private int _maxEnemiesCount;

        private int _currentEnemiesCount;
        private int _spawnedEnemies;
        private bool _isEndSpawn;

        public UnityEvent OnCompleteLevel = new();

        private void Start()
        {
            ThirdLevelEveneManager.Instance().OnSpawnEnemy.AddListener(OnSpawnedEnemy);
            ThirdLevelEveneManager.Instance().OnDieEnemy.AddListener(OnDiedEnemy);
        }

        private void OnSpawnedEnemy()
        {
            _currentEnemiesCount++;
            _spawnedEnemies++;

            if (_spawnedEnemies == _maxEnemiesCount)
            {
                ThirdLevelEveneManager.Instance().SendEndSpawnSignal();
                _isEndSpawn = true;
            }
        }

        private void OnDiedEnemy()
        {
            _currentEnemiesCount--;

            if (_isEndSpawn && _currentEnemiesCount == 0)
            {
                OnCompleteLevel.Invoke();
            }
        }
    }
}
