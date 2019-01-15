using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour
{

    //the current health
    public int health = 10;

    //the maximum health value
    public int maxHealth;

    //Event that is triggered when the character dies
    public UnityEvent onDie;

    //Event that is triggered when the character is damaged
    public OnDamagedEvent onDamaged;

    private bool dead = false;

    private void Start()
    {
        //sets the health of the character to the maxHealth value
        health = maxHealth;

        //sets the initial value for the health bar if the character has one
        gameObject.SendMessage("sendHealthData", maxHealth, SendMessageOptions.DontRequireReceiver);
    }

    //sends the health information of this gameobject back to the sender that triggered the method
    public void returnHealth(GameObject sender)
    {

        int[] healthInfo = new int[2];
        healthInfo[0] = health;
        healthInfo[1] = maxHealth;
        sender.SendMessage("setCurrentHealth", healthInfo, SendMessageOptions.DontRequireReceiver);
    }

    //used to subtract the damage amount from health
    public void TakeDamage(int damage)
    {

        //subtracts the value of damage from health
        health -= damage;

        //invoke the onDamaged event with the value of health
        if ( health > 0)
        {
            onDamaged.Invoke(health);
        }


        
        //destroys the game object if the health drops below 1
        if (health < 1 && dead == false)
        {
            dead = true;
            onDie.Invoke();
        }
        
        //updates the health
        updateHealth();
    }


    //Handles the restoration of health from pickups
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

       
        updateHealth();

    }

    //update the health displayed on the health bar
    public void updateHealth()
    {       
            gameObject.SendMessage("sendHealthData", health, SendMessageOptions.DontRequireReceiver);              
    }
}


