using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceShooter
{
    public class UIDisplay : MonoBehaviour
    {
        [SerializeField] Slider _healthSlider;
        [SerializeField] TextMeshProUGUI _scoreText;

        Health _playerHealth;

        private void Awake()
        {
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }

        private void Start()
        {
            _healthSlider.maxValue = _playerHealth.PlayerHealth;
            UpdatePlayerHealth();

            _playerHealth.onObjectHit += UpdatePlayerHealth;
            Health.onEnemyKilled += UpdateScore;
            LevelManager.onGameReset += UpdateScore;
        }

        void UpdatePlayerHealth()
        {
            _healthSlider.value = _playerHealth.PlayerHealth;
        }

        void UpdateScore()
        {
            _scoreText.text = ScoreKeeper.instance.Score.ToString("000000000");
        }

        private void OnDisable()
        {
            _playerHealth.onObjectHit -= UpdatePlayerHealth;
            Health.onEnemyKilled -= UpdateScore;
            LevelManager.onGameReset -= UpdateScore;
        }
    }
}
