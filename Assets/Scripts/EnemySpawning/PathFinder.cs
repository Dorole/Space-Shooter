using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PathFinder : MonoBehaviour
    {
        EnemySpawner _enemySpawner;
        SO_WaveConfiguration _waveConfig;
        List<Transform> _waypoints;
        int _currentWaypointIndex = 0;

        void Awake()
        {
            _enemySpawner = FindObjectOfType<EnemySpawner>();    
        }

        void Start()
        {
            _waveConfig = _enemySpawner.CurrentWave;
            _waypoints = _waveConfig.GetWaypoints();
            transform.position = _waypoints[_currentWaypointIndex].position;
        }

        void Update()
        {
                FollowPath();
        }

        void FollowPath()
        {
            if (_currentWaypointIndex < _waypoints.Count)
            {
                Vector3 targetPos = _waypoints[_currentWaypointIndex].position;
                float distanceDelta = _waveConfig.MoveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, distanceDelta);

                if (transform.position == targetPos)
                    _currentWaypointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
