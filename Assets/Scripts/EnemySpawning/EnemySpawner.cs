using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<SO_WaveConfiguration> _waveConfigs;
        [SerializeField] float _timeBetweenWaves;
        SO_WaveConfiguration _currentWave;
        
        [SerializeField] bool _isLooping;

        public SO_WaveConfiguration CurrentWave => _currentWave;

        void Start()
        {
            StartCoroutine(CO_SpawnEnemyWaves());
        }

        IEnumerator CO_SpawnEnemyWaves()
        {
            do
            {
                for (int i = 0; i < _waveConfigs.Count; i++)
                {
                    _currentWave = _waveConfigs[i];

                    for (int y = 0; y < _currentWave.GetEnemyCount; y++)
                    {
                        Instantiate(_currentWave.GetEnemyAtIndex(y),
                                    _currentWave.GetFirstWaypoint.position,
                                    Quaternion.Euler(0,0,180),
                                    transform);

                        yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
                    }

                    yield return new WaitForSeconds(_timeBetweenWaves);
                }

            } while (_isLooping);
        }
    }
}