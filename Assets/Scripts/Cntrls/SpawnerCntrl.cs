using System.Collections;
using System.Collections.Generic;
using Enemy;
using Globals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cntrls
{
    public class SpawnerCntrl : MonoBehaviour
    {
        [SerializeField] private List<EnemyHealth> _enemiesList;
        
        [SerializeField] private float _maxSpawnRate;
        [SerializeField] private float _minSpawnRate;
        
        [SerializeField] private float _maxSizeArea;
        [SerializeField] private GameObject _spawnerContainer;

        private bool _isEndSpawn;
        private void Start()
        {
            ThirdLevelEveneManager.Instance().OnEndSpawn.AddListener(() => _isEndSpawn =true);
            StartCoroutine(SpawnEnemy());
        }
        

        private IEnumerator SpawnEnemy()
        {
            if (_isEndSpawn)
            {
                yield break;
            }
            
            yield return new WaitForSeconds(Random.Range(_minSpawnRate, _maxSpawnRate));
            ThirdLevelEveneManager.Instance().SendSpawnEnemySignal();
            var enemyId = Random.Range(0, _enemiesList.Count);
            var enemySpawnPosition = new Vector3(Random.Range(-_maxSizeArea, _maxSizeArea), 0,
                Random.Range(-_maxSizeArea, _maxSizeArea));
            
            Instantiate(_enemiesList[enemyId], enemySpawnPosition, Quaternion.identity, _spawnerContainer.transform);
            
            StartCoroutine(SpawnEnemy());
        }
    }
}