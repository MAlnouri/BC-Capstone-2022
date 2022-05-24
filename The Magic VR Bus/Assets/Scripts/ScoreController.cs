using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static int playerScore;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //reset score for each level
        playerScore = 0;

        //load player data
        SaveSystem.LoadFromFile();
    }
    // update score display
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score: " + playerScore;
    }

    public void LevelOneSaveHighScore()
    {
        //if the player's current score exceeds the high score, overwrite the old high score
        if (playerScore > PlayerData.levelOneHighScore)
        {
            PlayerData.levelOneHighScore = playerScore;
            PlayerData.levelOneComplete = true;
            SaveSystem.SaveToFile();
        }
    }
    public void LevelTwoSaveHighScore()
    {
        //if the player's current score exceeds the high score, overwrite the old high score
        if (playerScore > PlayerData.levelTwoHighScore)
        {
            PlayerData.levelTwoHighScore = playerScore;
            PlayerData.levelTwoComplete = true;
            SaveSystem.SaveToFile();
        }
    }
}
