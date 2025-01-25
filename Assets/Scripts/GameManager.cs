using System;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public enum State
    {
        Start,
        Update,
        Stop,
    }
    
    public class Events
    {
        public static Action OnGameStart;
        public static Action OnGameOver;
        public static Action OnGameRestart;
    }

    private static State _currentState = State.Start;

    private static List<Action> Updates;
    
    static Game()
    {
        _currentState = State.Start;
        Updates = new List<Action>();

        Events.OnGameStart += OnGameStarted;
        Events.OnGameOver += OnGameStopped;
        Events.OnGameRestart += OnGameRestarted;
    }

    public static State GetState()
    {
        return _currentState;
    }
    
    public static void RunUpdate()
    {
        foreach (var update in Updates)
        {
            update?.Invoke();
        }
    }

    public static void AddUpdate(Action update)
    {
        if (Updates.Contains(update))
        {
            Debug.LogWarning("Trying to add an existing update to the game");
            return;
        }
        
        Updates.Add(update);
    }

    public static void RemoveUpdate(Action update)
    {
        if (!Updates.Contains(update))
        {
            Debug.LogWarning("Trying to remove an non-existing update from the game");
            return;
        }
        
        Updates.Remove(update);
    }

    private static void OnGameStarted()
    {
        _currentState = State.Update;
    }

    private static void OnGameStopped()
    {
        _currentState = State.Stop;
    }

    private static void OnGameRestarted()
    {
        _currentState = State.Start;
    }
}

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Game.GetState() == Game.State.Start)
        {
            Game.Events.OnGameStart?.Invoke();
            return;
        }

        if (Game.GetState() == Game.State.Update)
        {
            Game.RunUpdate();
        }
    }
}