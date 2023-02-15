using UnityEngine;
using UnityEngine.SceneManagement;


namespace Modhi.WhackAMole
{

    public class SceneChanger : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void GoBack()
        {
            SceneManager.LoadScene("Intro");
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
