using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace SpaceShooter
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;
        public static event Action onSceneLoaded;
        public static event Action onSceneOver;

        Animator _anim;
        string _levelToLoad;
        [SerializeField] AudioClip _levelTheme;
        public AudioClip LevelTheme => _levelTheme;

        private void Awake()
        {
            instance = this;
            _anim = GetComponent<Animator>();
        }

        private void Start()
        {
            Health.onPlayerDestroyed += LoadGameOverScreen;
            onSceneLoaded?.Invoke();
        }

        void LoadGameOverScreen()
        {
            FadeToLevel("GameOver");
        }

        public void FadeToLevel(string levelName)
        {
            onSceneOver?.Invoke();
            _levelToLoad = levelName;
            _anim.SetTrigger("FadeOut");
        }

        public void FadeToNextLevel()
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1; 
            FadeToLevel("Level " + nextLevel.ToString());
        }

        public void LoadLevel()
        {
            SceneManager.LoadScene(_levelToLoad);
        }

        public void QuitGame()
        {
            Debug.Log("Quitting the game...");
            Application.Quit();
        }

        private void OnDisable()
        {
            Health.onPlayerDestroyed -= LoadGameOverScreen;
        }
    }
}
