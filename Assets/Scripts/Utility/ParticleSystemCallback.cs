using UnityEngine;
using UnityEngine.Events;

public class ParticleSystemCallback : MonoBehaviour
{
    [SerializeField] private UnityEvent callback;

    private void OnParticleSystemStopped()
    {
        callback?.Invoke();
    }
}