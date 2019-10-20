using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
    public static event System.EventHandler OnPlayerDie;

    [SerializeField] int health = 100;
    public int Health { get => health; }

    [SerializeField] int maximumHealth = 100;
    public int MaximumHealth { get => maximumHealth; }

    bool alive = true;
    // public const int MAXIMUM_HEALTH = 100;

    public void Damage(int amount)
    {
        if (!alive) return;
        
        health -= amount;

        if (health <= 0)
        {
            OnPlayerDie?.Invoke(this, System.EventArgs.Empty);
            alive = false;
        }
    }
}
