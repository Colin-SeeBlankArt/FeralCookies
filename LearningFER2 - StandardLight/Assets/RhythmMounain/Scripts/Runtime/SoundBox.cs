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
            soundBite.Play("BassLoop");
        }
    }
}
