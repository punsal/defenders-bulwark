using System.Collections.Generic;
using Abstract;
using Enemies;
using Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private WaveCounter waveCounter;
    [SerializeField] private List<GameData> gameData;

    private void OnEnable()
    {
        Game.Events.WaveCompleted += OnWaveCompleted;
    }

    private void OnDisable()
    {
        Game.Events.WaveCompleted -= OnWaveCompleted;
    }

    private void Start()
    {
        Game.Machine.ChangeState(Game.Machine.State.Start);
        waveCounter.Initialize(0);
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

        if (Game.Machine.Current == Game.Machine.State.Card)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                Game.Events.OnCardSelected(0);
            }
            
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                Game.Events.OnCardSelected(1);
            }
            
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                Game.Events.OnCardSelected(2);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Game.Events.OnApplyCardEffect();
                StartGame();
            }
        }
    }

    private void OnApplicationQuit()
    {
        foreach (var data in gameData)
        {
            data.RevertChanges();
        }
    }

    public void StartGame()
    {
        var level = levelManager.GetLevel();
        enemyManager.Initialize(level.EnemySpawnData);
        waveCounter.StartWave();
        Game.Machine.ChangeState(Game.Machine.State.Update);
    }

    public void RestartGame()
    {
        Game.Machine.ChangeState(Game.Machine.State.Restart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnWaveCompleted()
    {
        Game.Machine.ChangeState(Game.Machine.State.Card);
    }
}