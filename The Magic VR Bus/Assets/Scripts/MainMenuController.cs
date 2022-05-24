using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject lvlOneHighScoreText;
    public GameObject lvlTwoHighScoreText;
    public GameObject lvlTwoPlayButton;
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
}
