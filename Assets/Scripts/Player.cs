using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject ring;
    
    private void OnEnable()
    {
        Game.Machine.OnStateChangeEvent += OnStateChanged;
    }

    private void OnDisable()
    {
        Game.Machine.OnStateChangeEvent -= OnStateChanged;
    }

    private void OnStateChanged(Game.Machine.State state)
    {
        if (state == Game.Machine.State.Update)
        {
            ring.SetActive(false);
        }
    }

    public void Lose()
    {
        Game.Machine.ChangeState(Game.Machine.State.Over);
    }
}