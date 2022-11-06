using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundBox : MonoBehaviour
{
    public AudioManager musicBites;

    void Awake()
    {
        musicBites = FindObjectOfType<AudioManager>();     

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {            
            musicBites.Play("BassA");
        }
    }

}

