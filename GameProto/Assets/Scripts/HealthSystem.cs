using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour
{

    //the current health
    private int health = 10;

    //the maximum health value
    public int maxHealth;

    //Event that is triggered when the character dies
    public UnityEvent onDie;

    //Event that is triggered when the character is damaged
    public OnDamagedEvent onDamaged;
   

    private void Start()
    {
        //sets the health of the character to the maxHealth value
        health = maxHealth;
    }


    //used to subtract the damage amount from health
    public void TakeDamage(int damage)
    {

        //subtracts the value of damage from health
        health -= damage;

        //invoke the onDamaged event with the value of health
        onDamaged.Invoke(health);

        //destroys the game object if the health drops below 1
        if (health < 1)
        {
            onDie.Invoke();
        }
        
        //updates the ui if the character is the player
        updatePlayerHealth();
    }

    public void pickupRestoreHealth(int amount)
    {   
        //Can't restore health above the maximum amount for the character
        if ((health + amount) <= maxHealth)
        {
            health += amount;
        }
        else
        {
            health = maxHealth;
        }

        //updates the ui if the character is the player, although non player characters can't typically interact with game objects on this layer
        updatePlayerHealth();

    }

    public void updatePlayerHealth()
    {
        //update the health if the game object is the player
        if (gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            gameObject.SendMessage("sendHealthData", health);
        }
    }
}


