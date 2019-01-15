using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class OnLevelComplete: UnityEvent { }

public class LevelEnd : MonoBehaviour {

    //An instance of the OnLevelComplete event
    public OnLevelComplete onComplete;

    //When the player enters the trigger, trigger what ever is tied to the onComplete event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SendMessage("stopGame");
            onComplete.Invoke();
        }
    }
}
