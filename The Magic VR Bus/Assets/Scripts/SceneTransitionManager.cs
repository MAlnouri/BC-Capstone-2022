using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitionManager : MonoBehaviour
{
    // Calls fade screen script to handle transition animation
    public FadeScreen fadeScreen;
    public GameObject fadeScreenObject;

    void OnTriggerEnter(Collider other)
    {
        // Starts coroutine to play animation
        StartCoroutine(GoToSceneRoutine());
    }

    // Set the fader screen object to active in the game
    // Having the screen inactive on start avoids issues with camera stuttering
    public void show()
    {
        fadeScreenObject.SetActive(true);
    }

    IEnumerator GoToSceneRoutine()
    {
        // Reveals the fader screen
        show();
        yield return new WaitForSeconds(2);
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
