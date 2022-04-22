using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject BrickCounter;
    public GameObject Loops;
    public GameObject LoopTick;
    public GameObject StateTicker;
    public static int brickCount;
    public static int loops = 0;
    public static int loopticker = 0;
    public static int stateticker = 0;

    //public GameObject Slider_Loop;  //this is intended to create a countdown with LoopMeter, which player must keep filled. 
    //public static int loopMeter = 100;  //this value is the trigger for State Machines
    //public static int loopMinus -=1;

    void Update()
    {
        BrickCounter.GetComponent<Text>().text = "Totals = " + brickCount;  //count all bricks
        Loops.GetComponent<Text>().text = "Loops = " + loops;  //count loopos, based on 10 bricks for each loop
        LoopTick.GetComponent<Text>().text = "Looop Ticker = " + loopticker;  //counter for the loops
        StateTicker.GetComponent<Text>().text = "State Ticker = " + stateticker;  //counts loops to check which State the Game is in

        if (loopticker >= 8) //for every x bricks, do the following:
        {
            loopticker = 0;
            Debug.Log("loop ticker reset");
            loops +=1;
            stateticker += 1;
        }

        if (stateticker >= 2) //for every x State counts, do the following
        {
            GameMngr.StateTick += 1;
            Debug.Log("statecount is reset");
            stateticker = 0;
        }
    }



}
