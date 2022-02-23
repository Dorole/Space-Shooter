using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class ScoreKeeper : MonoBehaviour
    {
        int _score = 0;
        public int Score => _score;
        [SerializeField] int _enemyPoints = 10;

        private void Awake()
        {
            Health.onEnemyKilled += UpdateScore;
        }

        private void UpdateScore()
        {
            _score += _enemyPoints;
            Mathf.Clamp(_score, 0, float.MaxValue);
        }

        private void ResetScore()
        {
            _score = 0;
        }
    }
}
