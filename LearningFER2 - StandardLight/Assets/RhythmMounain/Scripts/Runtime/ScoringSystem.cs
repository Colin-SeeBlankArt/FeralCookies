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

    public static int brickTick;
    public static int goodbrickTick;  //this will be a positive impact on loop count
    public static int badbrickTick; //this will be a negative impact on loop count
    public static int _penalty; //hit the bunny, get penalized

    public static int _loopTicker;

    public int pcScore;

    int totBrickCt;
    int goodBrickTot;
    int badBrickTot;

    public int loopGoal;
    public int stateGoal;


    int loopticker;

    int _gBricktkr;
    int _gBrick = 4;
    int _blBrick = 2;
    int _blBrktkr;
    int _prpBrick = 2;
    int _prpBrktkr;

    public int _winGame;

    private void Start()
    {
        
    }

    void Update()
    {
        pcScore = (totBrickCt - badBrickTot);

        goodBrickTot = goodbrickTick;
        badBrickTot = (badbrickTick + _penalty);
        totBrickCt = goodbrickTick + badbrickTick;

        BrickCounter.GetComponent<Text>().text = "Totals = " + totBrickCt;  //count all bricks
        PlayerScore.GetComponent<Text>().text = "Player Score: " + pcScore;
        Loops.GetComponent<Text>().text = "Loops = " + loopticker;  //count loopos, based on 10 bricks for each loop
        GBTick.GetComponent<Text>().text = "Good Brick = " + goodBrickTot; //counter for the green
        BBTick.GetComponent<Text>().text = "Bad Brick = " + badBrickTot;  //counter for the red  

        if (goodbrickTick >= _winGame)
        {
            GameManager._noteQuota ++;
        }

        if (_loopTicker >= _gBrick) 
        {           
            Debug.Log("Green Brick Tick");
            _loopTicker = 0;
            loopticker++;  
            _blBrktkr++;
        }

        if (_blBrktkr >= _blBrick)
        {
            Debug.Log("Blue Brick Tick");
            _blBrktkr = 0;
            _prpBrktkr++;
        }

        if (_prpBrktkr >= _prpBrick)
        {
            print("Purple Brick Count");
            _prpBrktkr = 0;
        }

    }
}

/*    
 *        void LoopCounter()
    {
        loopticker = 0;
        Debug.Log("loop ticker = " + loopticker);
        loops += 1;
        stateticker += 1;
    }
 *    
    public static int TICK
    {
        get { return _TICK; }
        set 
        { 
            _TICK = value;
            Debug.Log($"TICK changed to {_TICK}");
        }
    }
    private static int _TICK;        

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
