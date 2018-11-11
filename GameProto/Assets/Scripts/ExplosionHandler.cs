using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosionHandler : MonoBehaviour {

    public int damage;
    public float explosionLifespan;
    public GameObject target;
    private ParticleSystem particleSys;  

    private void Start()
    {     
        particleSys = GetComponent<ParticleSystem>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject == target || target == null)
        {
            collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

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
