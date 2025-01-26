using System.Collections.Generic;
using Abstract;
using Shooting;
using UnityEngine;

[CreateAssetMenu(menuName = "Create PlayerData", fileName = "PlayerData", order = 0)]
public class PlayerData : GameData
{
    [SerializeField] private List<AShooter.Type> startingTypes;
    public List<AShooter.Type> StartingTypes => startingTypes;

    public void Initialize(List<AShooter.Type> initialStartingTypes)
    {
        if (IsInitialized)
        {
            return;
        }
        
        startingTypes = initialStartingTypes;
        Initialized();
    }

    public void AddStartingType(AShooter.Type type)
    {
        startingTypes.Add(type);
    }
}