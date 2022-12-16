using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundBox : MonoBehaviour
{
    AudioManager musicBites;
    AudioSource musicSource;

    public static SoundBox instance;

    public int musicPause = 0;
    public bool startPoint;
    public bool bassATrig;
    public bool keysA1Ttrig;
    public bool keysA2Ttrig;
    public bool keysB1Trig;
    public static int _pause = 0;
    public bool _allStop = false;
    bool resetLoop=false;

    //these come from ScoringSystem
    public static bool _bassA = false; 
    public static bool _keysA1 =false;
    public static bool _keysA2 = false;
    public static bool _keysB1 = false; 
        

    void Awake()
    {
        musicBites = FindObjectOfType<AudioManager>();
        musicSource = FindObjectOfType<AudioSource>();
        instance = this;
    }
    private void Update()
    {
        if (_pause >= 1)
        {
            PauseMusic();
            _pause = 0;
        }
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
        //Fire/Stop BassA
        if (bassATrig && _bassA)
        {
            //musicBites.Play("BassA");
            Debug.Log("Bass A plays");
            LoopMachine._loopPanelToggle ++;

        }
        //fire Keys A
        if(keysA1Ttrig && _keysA1)
        {
            //musicBites.Play("KeysA1");
            Debug.Log("Keys A plays");
        }
        //fire Keys A2
        if (keysA2Ttrig && _keysA2)
        {
            //musicBites.Play("KeysA2");
            Debug.Log("Keys A2 plays");
        }
 
        //fire Keys B
        if (keysB1Trig && _keysB1)
        {
            musicBites.Play("KeysB1");
            Debug.Log("Keys B plays");
        }

    }

    void PauseMusic()
    {
        {
            musicBites.Stop("BassA");
            musicBites.Stop("KeysA1");
        }
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

