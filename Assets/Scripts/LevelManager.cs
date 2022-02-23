using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] float _loadDelay = 2f;

        private void OnEnable()
        {
            Health.onPlayerDestroyed += LoadGameOverScreen;
        }

        void LoadGameOverScreen()
        {
            StartCoroutine(CO_LoadGameOverWithDelay());
        }

        private void OnDisable()
        {
            Health.onPlayerDestroyed -= LoadGameOverScreen;
        }

        IEnumerator CO_LoadGameOverWithDelay()
        {
            yield return new WaitForSeconds(_loadDelay);
            SceneManager.LoadScene("GameOver");
        }
    }
}
