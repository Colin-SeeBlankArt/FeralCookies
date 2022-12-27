using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundBox : MonoBehaviour
{
    public static SoundBox instance;

    public int musicPause = 0;
    public bool startPoint;
    public static int _pause = 0;
    public bool _allStop = false;

    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayMusic();
        }
    }

    //this is tied to the scoring system, based on coin unlocks
    public void PlayMusic()
    {
        LoopMachine._loopToggle=1;
    }
}

/*
 *  
 *         else
        {
            musicBites.Stop("BassA");
        }
 * 
 */

