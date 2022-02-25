using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class ScoreKeeper : MonoBehaviour
    {
        public static ScoreKeeper instance;

        int _score = 0;
        public int Score => _score;
        [SerializeField] int _enemyPoints = 10;

        private void Awake()
        {
            if (instance != null)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            Health.onEnemyKilled += UpdateScore;
            LevelManager.onGameReset += ResetScore;
        }

        private void UpdateScore()
        {
            _score += _enemyPoints;
            Mathf.Clamp(_score, 0, float.MaxValue);
        }

        public void ResetScore()
        {
            _score = 0;
        }

        private void OnDisable()
        {
            Health.onEnemyKilled -= UpdateScore;
        }
    }
}
