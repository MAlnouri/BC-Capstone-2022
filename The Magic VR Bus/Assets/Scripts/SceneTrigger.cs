using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{

    // Triggers new scene on entering area
    void OnTriggerEnter(Collider other)
    {
        // Loads scene based on index in build settings
        SceneManager.LoadScene(2);
    }

}
