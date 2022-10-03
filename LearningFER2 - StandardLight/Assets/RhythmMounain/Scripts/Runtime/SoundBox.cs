using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundBox : MonoBehaviour
{
    public Sound[] sounds;
    
    public static SoundBox instance;

    void Awake()
    {
               
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Player"))
        {
            //soundBite.Play("BassLoopA"); 
            Play("BassA");
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}

//if (collider.CompareTage("Player") && (coinCount <= 25)
//      {
//          soundBite.Play(" ")
//      }