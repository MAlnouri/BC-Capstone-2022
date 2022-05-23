using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPlaySound : MonoBehaviour
{
    public AudioClip NarrationToPlay;
    public float Volume;
    AudioSource _Audio;
    public bool playOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        _Audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
        if (!playOnce)
        {
            _Audio.PlayOneShot(NarrationToPlay, Volume);
            playOnce = true;
        }
    }

}
