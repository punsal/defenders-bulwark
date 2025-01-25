using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Game.Machine.ChangeState(Game.Machine.State.Start);
    }

    private void Update()
    {
        if (Game.Machine.Current == Game.Machine.State.Start)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                StartGame();
                return;
            }
        }
        
        if (Game.Machine.Current == Game.Machine.State.Update)
        {
            Game.RunUpdate();
        }
    }

    public void StartGame()
    {
        Game.Machine.ChangeState(Game.Machine.State.Update);
    }

    public void RestartGame()
    {
        Game.Machine.ChangeState(Game.Machine.State.Restart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}