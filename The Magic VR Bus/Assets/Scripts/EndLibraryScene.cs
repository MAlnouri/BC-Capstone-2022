using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLibraryScene : MonoBehaviour
{
    // Calls fade screen script to handle transition animation
    public FadeScreen fadeScreen;
    public GameObject fadeScreenObject;
    // Calls scorecontroller to save score on level transition
    public GameObject scoring;
    public AudioClip NarrationToPlay;
    public float Volume;
    AudioSource _Audio;
    public bool playOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        _Audio = GetComponent<AudioSource>();
    }

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

    // Play the last message of the Library Scene
    public void PlayMessage()
    {
        if (!playOnce)
        {
            _Audio.PlayOneShot(NarrationToPlay, Volume);
            playOnce = true;
        }
    }

    IEnumerator GoToSceneRoutine()
    {
        // Play the Library narration message
        // Yield for message to complete
        PlayMessage();
        yield return new WaitForSeconds(7);

        // Reveals the fader screen
        show();

        // Saves current score
        scoring.GetComponent<ScoreController>().LevelTwoSaveHighScore();
        yield return new WaitForSeconds(2);

        // Fades the screen on loading new scene
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        // Launches new scene
        //SceneManager.LoadScene(sceneIndex);
        SceneManager.LoadScene(0);
    }
}
