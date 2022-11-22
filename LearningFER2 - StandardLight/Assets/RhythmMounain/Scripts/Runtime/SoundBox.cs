using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundBox : MonoBehaviour
{
    //[SerializeField]
    AudioManager musicBites;
    public int musicPause = 0;
    public bool startPoint;
    public bool bassA;
    public bool keysA;
    public static int _pause = 0;
    public bool resetLoop=false;
        

    void Awake()
    {
        musicBites = FindObjectOfType<AudioManager>();     
    }
    private void Update()
    {
        if (_pause >= 1)
        {
            PauseMusic();
            //_pause = 0;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayMusic();
        }
    }
    void PlayMusic()
    {
        if (startPoint)
        {
        musicBites.Play("BassA");
        }
        else
        {
            musicBites.Stop("BassA");
        }
            if(keysA)
        {
            musicBites.Play("KeysA1");
        }
        else
        {
            musicBites.Stop("KeysA1");
            }
    }
    void PauseMusic()
    {
        {
            musicBites.Stop("BassA");
            musicBites.Stop("KeysA1");
        }
    }

    void ResetLoopCount()
    {
       if (resetLoop)
        {
            LoopMachine._resetLoopCount++;
        }
    }

}

