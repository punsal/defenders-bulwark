using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        if (Game.Machine.Current == Game.Machine.State.Start)
        {
            Game.Machine.ChangeState(Game.Machine.State.Update);
        }
    }

    private void Update()
    {
        if (Game.Machine.Current == Game.Machine.State.Update)
        {
            Game.RunUpdate();
        }
    }
}