using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosionHandler : MonoBehaviour {

    //The amount of damage the explosion inflicts
    public int damage;
    
    //The desired target of the explosion
    public GameObject target;

    //The particle system involved in the explosion
    private ParticleSystem particleSys;  

    private void Start()
    {     
        //get the particle system from this gameobject
        particleSys = GetComponent<ParticleSystem>();
    }

    //If the target enters the collision, they will take the specified amount of damage
    public void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject == target || target == null)
        {
            collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

    //Makes sure that the particle system is removed from the scene once it is no longer required
    private void Update()
    {
        if (particleSys)
        {
            if (!particleSys.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
