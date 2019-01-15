using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelInteract : MonoBehaviour {

    public UnityEvent OnInteract;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetButton("Interact"))
        {
            OnInteract.Invoke();
        }
    }
}
