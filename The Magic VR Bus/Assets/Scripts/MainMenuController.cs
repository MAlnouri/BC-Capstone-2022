using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // High scores
    public GameObject lvlOneHighScoreText;
    public GameObject lvlTwoHighScoreText;

    // Buttons
    public GameObject lvlTwoPlayButton;

    // Audio settings
    public AudioSource audioSourceIntro;
    public float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //load data from file if there is any
        SaveSystem.LoadFromFile();
        //display high scores
        lvlOneHighScoreText.GetComponent<Text>().text = PlayerData.levelOneHighScore.ToString();
        lvlTwoHighScoreText.GetComponent<Text>().text = PlayerData.levelTwoHighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckLevelTwoPrerequisite()
    {
        if (PlayerData.levelOneComplete == false)
        {
            lvlTwoPlayButton.SetActive(false);
        }
        else 
        {
            lvlTwoPlayButton.SetActive(true);
        }
    }

    public void StartLevelOne()
    {
        LoadLevel("Level 1 Redesign");
    }

    public void StartLevelTwo()
    {
        LoadLevel("Level 2 Scene");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayIntroAudio()
    {
        if (audioSourceIntro.isPlaying)
        {
            audioSourceIntro.Stop();
            PlayIntroAudio();
        }
        else
        {
            audioSourceIntro.PlayOneShot(audioSourceIntro.clip, volume);
        }
    }
}
