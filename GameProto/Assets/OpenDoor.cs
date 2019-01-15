using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public GameObject openDoor;

	public void open()
    {
        Instantiate(openDoor, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
