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

        //? record the coin type
        //define publicly how many points for or against in player speed, coin count, time variable

        //boom light is idle until collision, then
            //play fmod sound, note~hertz for this location
            //play animator light_boom
            //play animator sphere_boom
            //when light_boom is done, then:
            //particle effect

        ScoringSystem.brickCount += 1;
        ScoringSystem.loopticker += 1;

        Destroy(gameObject);

        Debug.Log(" bricks must die ");


    }

}
