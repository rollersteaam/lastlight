using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 100;
    public int Health { get => health; }

    [SerializeField] int maximumHealth = 100;
    public int MaximumHealth { get => maximumHealth; }
    // public const int MAXIMUM_HEALTH = 100;

    public void Damage(int amount)
    {
        health -= amount;
        Debug.Log(health);
    }
}
