using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject BrickCounter;
    public GameObject PlayerScore;
    public GameObject Loops;
    public GameObject GBTick; 
    public GameObject BBTick;


    public static int brickCount; //fed from ScoryingSystem
    public static int brickTick;
    public static int goodbrickTick;  //this will be a positive impact on loop count
    public static int badbrickTick; //this will be a negative impact on loop count

    int pcScore;

    int totBrickCt;
    int goodBrickTot;
    int badBrickTot;
    //int totalScore;
    int playerScore;

    public int loopGoal;
    public int stateGoal;

    int loops;
    int loopticker;
    int state;
    int stateticker;

    private void Start()
    {

    }

    void Update()
    {
        BrickCounter.GetComponent<Text>().text = "Totals = " + totBrickCt;  //count all bricks
        PlayerScore.GetComponent<Text>().text = "Player Score:" + playerScore;
        Loops.GetComponent<Text>().text = "Loops = " + loops;  //count loopos, based on 10 bricks for each loop
        GBTick.GetComponent<Text>().text = "Good Brick = " + goodBrickTot;  //counter for the green
        BBTick.GetComponent<Text>().text = "Bad Brick = " + badBrickTot;  //counter for the purp

        goodBrickTot = goodbrickTick;
        badBrickTot = badbrickTick;
        totBrickCt = brickCount;
        playerScore = goodBrickTot;

        pcScore = totBrickCt - badBrickTot;

        if (brickTick == loopGoal)  //set adding to the loops, resest counter
        {
            loops += 1;
            loopticker += 1;
            brickTick = 0;
        }
        if (loopticker >= stateGoal) //set for the State, reset loop ticker
        {
            GameManager.StateTick += 1;
            stateticker += 1;
            Debug.Log("statecount is reset");
            loopticker = 0;
        }

    }

}

/*
 *      
        loopticker += goodbrickTick - (badbrickTick);

        if (loopticker >= loopTickGoal) //for every x bricks, do the following:
        {
            loopticker = 0;
            Debug.Log("loop ticker reset");
            loops +=1;
            stateticker += 1;
        }

        if (stateticker >= statetickerGoal) //for every x State counts, do the following
        {
            GameManager.StateTick += 1;
            Debug.Log("statecount is reset");
            stateticker = 0;
        }

*/
