using System;
using Abstract;
using UnityEngine;

[CreateAssetMenu(menuName = "Create WaveCounter", fileName = "WaveCounter", order = 0)]
public class WaveCounter : GameData
{
    [SerializeField] private int wave;
    
    public int Wave => wave;
    
    public event Action OnWaveUpdated;

    public void Initialize(int startingWave)
    {
        wave = startingWave;
    }
    
    public void StartWave()
    {
        wave++;
        OnWaveUpdated?.Invoke();
    }
}