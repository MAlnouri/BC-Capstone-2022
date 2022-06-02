using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitionManager : MonoBehaviour
{
    // Calls fade screen script to handle transition animation
    public FadeScreen fadeScreen;

    /*
    public void GoToScene()
    {
        // Starts coroutine to play animation
        // Uses next scene index as parameter to load new scene
        StartCoroutine(GoToSceneRoutine());
    }*/

    void OnTriggerEnter(Collider other)
    {
        // Starts coroutine to play animation
        StartCoroutine(GoToSceneRoutine());
    }

    IEnumerator GoToSceneRoutine()
    {
        // Fades the screen on loading new scene
        fadeScreen.FadeOut();

        // Coroutine allows time for animation to play
        // Wait for animation
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        // Launches new scene
        //SceneManager.LoadScene(sceneIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

}
