using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class UIButtons : MonoBehaviour
    {
        public void LoadGame(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame()
        {
            Debug.Log("Quitting the game...");
            Application.Quit();
        }
    }
}
