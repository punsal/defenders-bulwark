using System;
using System.Collections.Generic;
using Enemies;
using Shooting;
using UnityEngine;

public static class Game
{
    public static class Machine
    {
        public enum State
        {
            Start,
            Update,
            Card,
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
        public static event Action<Enemy> Destroyed;
        public static event Action WaveCompleted;
        public static event Action<int> CardSelected;
        public static event Action AppleCardEffect;
        
        public static event Action AddBubble;

        public static event Action<AShooter.Type> AddShooter;

        public static void OnDestroyed(Enemy enemy)
        {
            Destroyed?.Invoke(enemy);
        }

        public static void OnWaveCompleted()
        {
            WaveCompleted?.Invoke();
        }

        public static void OnCardSelected(int card)
        {
            CardSelected?.Invoke(card);
        }

        public static void OnApplyCardEffect()
        {
            AppleCardEffect?.Invoke();
        }

        public static void OnAddBubble()
        {
            AddBubble?.Invoke();
        }

        public static void OnAddShooter(AShooter.Type type)
        {
            AddShooter?.Invoke(type);
        }
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