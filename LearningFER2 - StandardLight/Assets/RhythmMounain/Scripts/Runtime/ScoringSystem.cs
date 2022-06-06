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
    public Text textobject;

    public static int brickCount; 
    public static int brickTick;
    public static int goodbrickTick;  //this will be a positive impact on loop count
    public static int badbrickTick; //this will be a negative impact on loop count

    public int pcScore;

    int totBrickCt;
    int goodBrickTot;
    int badBrickTot;

    public int loopGoal;
    public int stateGoal;

    int loops;
    int loopticker;
    int state;
    int stateticker;

    public int _winGame = 64;

    void Update()
    {
        pcScore = (totBrickCt - badBrickTot);

        goodBrickTot = goodbrickTick;
        badBrickTot = badbrickTick;
        totBrickCt = brickCount;

        BrickCounter.GetComponent<Text>().text = "Totals = " + totBrickCt;  //count all bricks
        PlayerScore.GetComponent<Text>().text = "Player Score: " + pcScore;
        Loops.GetComponent<Text>().text = "Loops = " + loops;  //count loopos, based on 10 bricks for each loop
        GBTick.GetComponent<Text>().text = "Good Brick = " + goodBrickTot; //counter for the green
        BBTick.GetComponent<Text>().text = "Bad Brick = " + badBrickTot;  //counter for the purp  

        if (pcScore >= _winGame)
        {
            GameManager._noteQuota ++;
        }
    }

}

/*    
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
////         

        if (brickTick == loopGoal)  //set adding to the loops, resest counter
        {
            loops += 1;
            loopticker += 1;
            //brickTick = 0;
        }
        if (loopticker >= stateGoal) //set for the State, reset loop ticker
        {
            GameManager.StateTick += 1;
            stateticker += 1;
            Debug.Log("statecount is reset");
            loopticker = 0;
        }
*/
