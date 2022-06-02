using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialFadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;
    public GameObject initialFaderScreen;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        // Starts scene with fade in
        if (fadeOnStart) FadeIn();
        // Hides the initial fade screen after fade is complete
        initialFaderScreen.SetActive(false);
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    // Update is called once per frame
    public void Fade(float alphaIn, float alphaOut)
    {
        // Starts coroutine to play animation
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        // Loops until timer reaches fade duration 2 seconds
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            // Selects new color alphaOut
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            // Sets material to new color value
            rend.material.SetColor("_Color", newColor);

            // Adds delta time to current timer
            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        // Selects new color alphaOut
        newColor2.a = alphaOut;

        // Sets material to new color value
        rend.material.SetColor("_Color", newColor2);
    }
}
