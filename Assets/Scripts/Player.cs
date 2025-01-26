using System.Collections.Generic;
using Shooting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private List<AShooter.Type> startingTypes;
    [SerializeField] private GameObject ring;
    [SerializeField] private List<GameObject> orbits;
    [SerializeField] private List<AShooter> shooters;
    
    private void OnEnable()
    {
        Game.Machine.OnStateChangeEvent += OnStateChanged;
        Game.Events.AddBubble += OnAddBubble;
        Game.Events.AddShooter += OnAddShooter;
    }

    private void OnDisable()
    {
        Game.Machine.OnStateChangeEvent -= OnStateChanged;
        Game.Events.AddBubble -= OnAddBubble;
        Game.Events.AddShooter -= OnAddShooter;
    }

    private void Start()
    {
        playerData.Initialize(playerData.StartingTypes);
        foreach (var shooter in shooters)
        {
            shooter.gameObject.SetActive(playerData.StartingTypes.Contains(shooter.ShooterType));
        }
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

    private void OnAddBubble()
    {
        for (var i = 0; i < orbits.Count; i++)
        {
            var orbit = orbits[i];
            orbit.SetActive(true);
        }
    }

    private void OnAddShooter(AShooter.Type type)
    {
        var shooter = shooters.Find(x => x.ShooterType == type);
        shooter.gameObject.SetActive(true);
        playerData.AddStartingType(type);
    }
}