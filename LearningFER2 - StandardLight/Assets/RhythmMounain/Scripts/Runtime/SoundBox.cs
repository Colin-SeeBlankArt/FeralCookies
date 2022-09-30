using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    public static SoundBox instance;
    private AudioManager soundBite;

    void Awake()
    {
        soundBite = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Player"))
        {            
            soundBite.Play("BassLoopA"); 

        }
    }
}

//if (collider.CompareTage("Player") && (coinCount <= 25)
//      {
//          soundBite.Play(" ")
//      }