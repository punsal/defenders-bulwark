using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health", menuName = "Health")]
public class Health : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int healthPoints;
    public event Action OnHealed;
    public event Action OnDamaged;
    public event Action OnDeath;

    public void Heal(int amount)
    {
        healthPoints += amount;
        if (healthPoints >= maxHealth)
        {
            healthPoints = maxHealth;
        }
        OnHealed?.Invoke();
    }
    
    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints < 0)
        {
            OnDeath?.Invoke();
            return;
        }
        OnDamaged?.Invoke();
    }
    
}
