using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject startScreen;
        [SerializeField] private GameObject gameScreen;
        [SerializeField] private GameObject gameOverScreen;

        private void Start()
        {
            startScreen.SetActive(false);
            gameScreen.SetActive(false);
            gameOverScreen.SetActive(false);
        }

        private void OnGameStarted()
        {
            startScreen.SetActive(false);
            gameScreen.SetActive(false);
            gameOverScreen.SetActive(false);
        }
        

        private void OnGameOver()
        {
            startScreen.SetActive(false);
            gameScreen.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }
}
