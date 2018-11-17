using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyOnDie : MonoBehaviour
{
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
            Invoke("Destroy", 0.1f);
        }
        else
        {
            Destroy();
        }
        
        
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
