using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorTrapTrigger : MonoBehaviour {

    public UnityEvent OnTrapTriggered;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OnTrapTriggered.Invoke();
        }
        
    }
}
