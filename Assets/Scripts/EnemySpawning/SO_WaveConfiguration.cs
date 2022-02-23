using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
    public class SO_WaveConfiguration : ScriptableObject
    {
        [SerializeField] List<GameObject> _enemies;
        [SerializeField] Transform _pathPrefab;
        [SerializeField] float _moveSpeed = 5f;
        [Space]
        [Header("SpawnFrequency")]
        [SerializeField] float _timeBetweenEnemySpawns = 1f;
        [SerializeField] float _spawnTimeVariance = 1f;
        [SerializeField] float _minimumSpawnTime = 0.2f;

        public float MoveSpeed { get => _moveSpeed; }

        public Transform GetFirstWaypoint => _pathPrefab.GetChild(0);

        //public int GetEnemyCount => _enemies.Count;
        public int GetEnemyCount => _enemies.Count;

        public GameObject GetEnemyAtIndex(int index)
        {
            return _enemies[index];
        }
        
        public List<Transform> GetWaypoints()
        {
            List<Transform> waypoints = new List<Transform>();

            foreach (Transform waypoint in _pathPrefab)
                waypoints.Add(waypoint);

            return waypoints;
        }

        public float GetRandomSpawnTime()
        {
            float spawnTime = Random.Range(_timeBetweenEnemySpawns - _spawnTimeVariance,
                                           _timeBetweenEnemySpawns + _spawnTimeVariance);
            return Mathf.Clamp(spawnTime, _minimumSpawnTime, float.MaxValue);
        }

    }
}
