using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioBox : MonoBehaviour
{
    AudioSource audioSource;
    public static int _pause = 0;
    public static bool _loop = false;
    private bool _canPlay = false;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(_pause == 1)
        {
            audioSource.Pause();
        }
        if(_loop)
        {
            audioSource.loop = true;
        }
        if(_canPlay)
        {
            AudioBoxPlaying();
        }
    }

    public void AudioBoxPlaying()
    {
        if (!audioSource.isPlaying)
        {
            //wait the time of the length of the loop to move to the next step
            Debug.Log("Audio stopped");
            gameObject.SetActive(false);
        }
    }
}