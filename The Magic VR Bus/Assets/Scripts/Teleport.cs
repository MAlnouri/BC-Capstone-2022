using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportLocation;
    public GameObject theXR_Rig;

    void OnTriggerEnter(Collider other)
    {
        theXR_Rig.transform.position = teleportLocation.transform.position;
    }
    
}
