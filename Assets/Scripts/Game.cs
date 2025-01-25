using System;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static class Machine
    {
        public enum State
        {
            Start,
            Update,
            Over,
            Restart,
        }

        public static State Current { get; private set; } = State.Start;
        public static event Action<State> OnStateChangeEvent;

        public static void ChangeState(State newState)
        {
            Current = newState;
            OnStateChangeEvent?.Invoke(Current);
        }
    }
    
    public static class Events
    {
        
    }

    private static readonly Queue<Action> AddUpdatesQueue;
    private static readonly Queue<Action> RemoveUpdatesQueue;
    private static readonly List<Action> Updates;
    
    static Game()
    {
        AddUpdatesQueue = new Queue<Action>();
        RemoveUpdatesQueue = new Queue<Action>();
        Updates = new List<Action>();
        
        Machine.ChangeState(Machine.State.Start);
    }
    
    public static void RunUpdate()
    {
        while (AddUpdatesQueue.Count > 0)
        {
            var action = AddUpdatesQueue.Dequeue();
            AddUpdateInternal(action);
        }
        
        while (RemoveUpdatesQueue.Count > 0)
        {
            var action = RemoveUpdatesQueue.Dequeue();
            RemoveUpdateInternal(action);
        }
        
        foreach (var update in Updates)
        {
            update?.Invoke();
        }
    }

    public static void AddUpdate(Action update)
    {
        AddUpdatesQueue.Enqueue(update);
    }

    private static void AddUpdateInternal(Action update)
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
        RemoveUpdatesQueue.Enqueue(update);
    }

    private static void RemoveUpdateInternal(Action update)
    {
        if (!Updates.Contains(update))
        {
            Debug.LogWarning("Trying to remove an non-existing update from the game");
            return;
        }
        
        Updates.Remove(update);
    }
}