using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour {

    //the health bar slider in the ui
    public Slider healthBar;

    //the amount of health to subtract
    public int healthToSub;

    private void OnEnable()
    {
        ControlPlayer.OnHealthUpdate += UpdateHealthBar;
        
    }
    private void OnDisable()
    {
        ControlPlayer.OnHealthUpdate -= UpdateHealthBar;
        
    }
    private void UpdateHealthBar(int health)
    {
        healthToSub = health;
        healthBar.value = health;
    }
}
