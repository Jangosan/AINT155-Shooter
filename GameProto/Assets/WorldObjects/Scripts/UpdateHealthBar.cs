using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthBar : MonoBehaviour {

    //the health bar slider in the ui
    public Slider healthBar;



    public void Start()
    {
        healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();
    }

    //update the health bar with the amount of health the player has
    public void sendHealthData(int health)
    {
        changeHealthBar(health);
    }

    private void changeHealthBar(int health)
    {
        healthBar.value = health;
    }
}
