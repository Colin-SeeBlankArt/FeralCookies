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
        //?  would it be better to have player know lane, and the note know which lane (this is the note it could reperesent)

        ScoringSystem.theScore += 50;

        Destroy(gameObject);

        Debug.Log(" bricks must die ");

    }

}
