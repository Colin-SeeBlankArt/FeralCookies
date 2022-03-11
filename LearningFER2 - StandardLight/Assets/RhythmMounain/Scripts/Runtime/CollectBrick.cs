using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBrick : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter()
    {
        collectSound.Play();
        Debug.Log(" did I make a sound ");

        ScoringSystem.theScore += 50;

        Destroy(gameObject);

        Debug.Log(" bricks must die ");

    }

}
