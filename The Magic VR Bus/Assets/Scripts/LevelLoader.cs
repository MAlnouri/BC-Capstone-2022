using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f; // Variable transition time

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        // Starts coroutine to play animation
        // Uses next scene index as parameter to load new scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    // Coroutine allows time for animation to play
    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation titled with string
        transition.SetTrigger("Start");

        // Wait for animation
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }

    // Use trigger transition for player entering bus
    // Triggers new scene on entering area
    void OnTriggerEnter(Collider other)
    {
        // Starts coroutine to play animation
        // Uses next scene index as parameter to load new scene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

}
