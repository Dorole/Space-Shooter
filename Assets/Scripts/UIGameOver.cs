using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _scoreText;
        ScoreKeeper _scoreKeeper;

        private void Awake()
        {
            _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        }

        private void Start()
        {
            _scoreText.text = "You scored:\n" + _scoreKeeper.Score;
        }
    }
}
