using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static int playerScore;
    public GameObject scoreText;

    // update score display
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score: " + playerScore;
    }
}
