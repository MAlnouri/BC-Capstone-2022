using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideText : MonoBehaviour
{
    public GameObject TextObj1;
    public GameObject TextObj2;

    void OnTriggerEnter(Collider other)
    {
        // Hides both text objects selected
        hide(TextObj1);
        hide(TextObj2);
    }

    // Method to hide object parameter
    public void hide(GameObject obj)
    {
        obj.SetActive(false);
    }
}
