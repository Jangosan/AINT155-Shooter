using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyOnDie : MonoBehaviour
{

    //If true, child objects with the enemy tag will be detached when this game object dies
    public bool preserveChildrenOnDeath = false;

    
    public void Die()
    {
        //Loops through all children and detaches each child that has the Enemy tag , delayed destruction so that children don't disable their components and become inactive
        if (preserveChildrenOnDeath == true)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).tag == "Enemy")
                {
                    gameObject.transform.GetChild(i).parent = null;
                }
            }
            //A delay that allows the children to be unparented properly before the object is destroyed 
            Invoke("Destroy", 0.1f);
        }

        //Standard operation for most enemies
        else
        {
            Destroy();
        }
        
        
    }

    //Destroy the game object
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
