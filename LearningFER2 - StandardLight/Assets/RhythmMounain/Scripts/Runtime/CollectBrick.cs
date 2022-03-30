using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBrick : MonoBehaviour
{
  //want  to add public Fmod variable to play sound
  //define where notes are located define what note they actually are. This can be based on lanerunner lane number

    void OnTriggerEnter()
    {
        //play fmod sound, note~hertz for this location
        //? record the coin type
        //define publicly how many points for or against in player speed, coin count, time variable
        //particle effect

        ScoringSystem.theScore += 1;
        ScoringSystem.currentBrickcount += 1;

        Destroy(gameObject);

        Debug.Log(" bricks must die ");


    }

}
