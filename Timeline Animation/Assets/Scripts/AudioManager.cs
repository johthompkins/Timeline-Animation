using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip firstAnswer;
    public float delay = 2f;

    private void Start()
    {
        Invoke("PlayDelayedAudio", delay);
    }

    private void PlayDelayedAudio()
    {
        if (firstAnswer != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = firstAnswer;
            audioSource.Play();
        }
    }
}
