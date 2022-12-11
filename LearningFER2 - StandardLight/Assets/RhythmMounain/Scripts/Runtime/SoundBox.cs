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
        
        //Fire/Stop BassA
        if (bassATrig && _bassA)
        {
            musicBites.Play("BassA");
            Debug.Log("Bass A plays");          
        }
        //fire Keys A
        if(keysA1Ttrig && _keysA1)
        {
            musicBites.Play("KeysA1");
            Debug.Log("Keys A plays");

        }
        //fire Keys B
        if(keysB1Trig && _keysB1)
        {
            musicBites.Play("KeysB1");
            Debug.Log("Keys B plays");
        }
        //fire Keys A2
        if (keysA2Ttrig && _keysA2)
        {
            musicBites.Play("KeysA2");
            Debug.Log("Keys A2 plays");
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

/*
 *  
 *         else
        {
            musicBites.Stop("BassA");
        }
 * 
 */

