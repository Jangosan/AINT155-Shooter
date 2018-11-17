using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SpiderAttack : MonoBehaviour {

    public int damage;
    public UnityEvent onExplode;
    public float explosionLifetime;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player;

        player = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject == player)
        {
            collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);


            Invoke("cleanUp", explosionLifetime);
        }
    }


    private void cleanUp()
    {
        onExplode.Invoke();
    }


}
