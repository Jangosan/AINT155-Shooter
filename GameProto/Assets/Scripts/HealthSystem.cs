using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour
{

    public int health = 10;
    private int maxHealth;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;

    private void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        onDamaged.Invoke(health);

        if (health < 1)
        {
            onDie.Invoke();
        }
    }

    public void pickupRestoreHealth(int amount)
    {   
        if ((health + amount) <= maxHealth)
        {
            health += amount;
        }
        else
        {
            health = maxHealth;
        }

    }
}


