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


    void Update()
    {
        BrickCounter.GetComponent<Text>().text = "Totals = " + brickCount;  //count all bricks
        Loops.GetComponent<Text>().text = "Loops = " + loops;  //count loopos, based on 10 bricks for each loop
        LoopTick.GetComponent<Text>().text = "Looop Ticker = " + loopticker;  //counter for the loops
        StateTicker.GetComponent<Text>().text = "State Ticker = " + stateticker;  //counts loops to check which State the Game is in

        if (loopticker >= 8) //fore every 10 bricks, do the following:
        {
            loopticker = 0;
            Debug.Log("loop ticker reset");
            loops +=1;
            stateticker += 1;
        }

        if (stateticker >= 2) //for every 4 State counts, do the following
        {
            GameMngr.StateTick += 1;
            Debug.Log("statecount is reset");
            stateticker = 0;
        }
    }



}
