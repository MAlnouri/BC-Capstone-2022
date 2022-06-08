using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageObjectActiveState : MonoBehaviour
{
    public bool isActive;
    public GameObject ObjectToManage;

    void OnTriggerEnter(Collider other)
    {
        ObjectToManage.SetActive(isActive);
    }
}
