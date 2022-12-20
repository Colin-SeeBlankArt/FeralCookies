using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioBox : MonoBehaviour
{
    AudioSource audioSource;
    public static int _pause = 0;
    public static bool _loop = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    void Update()
    {
        EndPlaying();

        if (_pause == 1)
        {
            audioSource.Pause();
        }
        else { audioSource.UnPause(); }
        
        if(_loop)
        {
            audioSource.loop = true;
        }
        //else { EndPlaying(); }
    }

    public void EndPlaying()
    {
        if (!audioSource.isPlaying)
        {           
            //this.gameObject.SetActive(false); 
            LoopMachine._playNextTrack = true; //toggle next track of song
        }
    }
}