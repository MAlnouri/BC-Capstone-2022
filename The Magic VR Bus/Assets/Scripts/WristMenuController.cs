using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WristMenuController : MonoBehaviour
{
    public GameObject wristUI;
    List<GameObject> uiLayers = new List<GameObject>();
    public bool isUIActive = true;
    private bool blockAction = false;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Main Menu") 
        {
            blockAction = true;
        }
        else
        {
            foreach (Transform tran in wristUI.transform)
            {
                uiLayers.Add(tran.gameObject);
            }
        }
        DisplayWristUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if(context.performed && blockAction != true) DisplayWristUI();
    }

    public void DisplayWristUI()
    {
        if(isUIActive)
        {
            foreach (GameObject layer in uiLayers)
            {
                if (layer.activeSelf == true) layer.SetActive(false);
            }
            isUIActive = false;
        }
        else
        {
            foreach (GameObject layer in uiLayers)
            {
                if (layer.name == "Top Level") layer.SetActive(true);
            }
            isUIActive = true;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Level 1 Redesign");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level 2 Scene");
    }

    public void LoadSceneDevPlayground()
    {
        SceneManager.LoadScene("Dev Playground (Internal Use Only)");
    }
}
