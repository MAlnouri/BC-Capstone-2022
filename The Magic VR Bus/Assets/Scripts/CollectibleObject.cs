using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    // properties set in the editor
    public int objectScoreValue;
    public bool ignoreCollectionByCollision;
    
    // collect item via the activate event on an XR interactable object
    public void CollectObject()
    {
        ScoreController.playerScore += objectScoreValue;
        Destroy(gameObject);
    }

    // collect item via a collision (throw an object at or shoot object to collect it)
    // gameObject's collidor must be set as a trigger for this method to function properly
    void OnTriggerEnter(Collider other)
    {
        if (ignoreCollectionByCollision) 
        {
            return;
        } 
        else 
        {
            ScoreController.playerScore += objectScoreValue;
            Destroy(gameObject);
        }
    }
}
