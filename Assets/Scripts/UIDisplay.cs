using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceShooter
{
    public class UIDisplay : MonoBehaviour
    {
        [SerializeField] Slider _healthSlider;
        [SerializeField] TextMeshProUGUI _scoreText;

        ScoreKeeper _scoreKeeper;
        Health _playerHealth;

        private void Awake()
        {
            _scoreKeeper = FindObjectOfType<ScoreKeeper>();
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }

        private void Start()
        {
            _healthSlider.maxValue = _playerHealth.PlayerHealth;
            UpdatePlayerHealth();
            UpdateScore();

            _playerHealth.onObjectHit += UpdatePlayerHealth;
            Health.onEnemyKilled += UpdateScore;
        }

        void UpdatePlayerHealth()
        {
            _healthSlider.value = _playerHealth.PlayerHealth;
        }

        void UpdateScore()
        {
            _scoreText.text = _scoreKeeper.Score.ToString("000000000");
        }
    }
}
