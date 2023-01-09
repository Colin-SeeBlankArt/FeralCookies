using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    //store data
    public static void RecordResults()
    {
        var sessionData = new GameSessionData()
        {
            TimeCreated = DateTime.UtcNow,
            TotalBricks = brickTick,
            PlayerScore = pcScore,            
            RedStack = _redTick,
            BlueStack = _blueStack,
            PurpStack = _purpStack

            /* GreenStack = _greenTick,
             * GrnSprkTot = (create from GBunny),
             * RdSprkTot = (crearte from RBunny),
             * PollQuest_[Loop] = (Polls),
             * TimeElapsed = timeElapsed,
             */
        };

        SaveManager.Instance.SaveData("SessionData", sessionData);
        AnalyticsManager.SaveDataAsync("SessionData", sessionData);
    }

    //text of data
    public GameObject BrickCounter;
    public GameObject PlayerScore;
    public GameObject Loops;
    public GameObject GBTick;
    public GameObject BBTick;

    //UI Element which activates Buttons for Songs
    public GameObject LoopLists;

    ///// Major Counter
    //actual score variable
    public static int _greenBrickTicker;

    ////Poll Values
    public static int _pollLevel = 0; //values from Poll Pop Up

    // coming from CollectBrick
    public static int brickTick;
    public static int _greenTick;   //this will be a positive impact on loop count
    public static int _redTick;     //this will be a negative impact on loop count
    public static int _purpTick;    //unlocks future items
    public static int _blueTick;    //unlocks future items

    public static int _greenStack;  //green collection
    int _negativeBrickTick;
    
    public static int _penalty; //hit the bunny, get penalized

    public static int _blueStack; //blue coin stack
    public static int _purpStack; //purple coin stack

    public static int pcScore;
    int _maxScore;

    public static int _resetScores = 0; //GameManger, Reset Level
    public static int _resetALL = 0; //GAmeManger, Reset All counters

    int totBrickCt;
    int goodBrickTot;

    int loopticker;
    int _gBricktkr;
    int _blBrktkr;                          // Ticker for Purple Bricks 
    int _blueCounter;
    int _prpBrktkr;                         // Tcker for furture Brick colors
    int _purpCounter;

    [SerializeField] private int _blueBrickGoals;   // Trigger for + Blue Brick 
    [SerializeField] private int _purpleBrickGoals; // Trigger for + Purple Brick
    [SerializeField] private int _LvlWGoals;        // Trigger for Level Winning

    [SerializeField]
    int _winLevel;

    private void Start()
    {
        ResetALL();                    
    }

    void Update()
    {       
        CoinCounter();
        PollingData();

        brickTick = brickTick + totBrickCt;        
        pcScore = totBrickCt + _maxScore + _blueTick + _purpTick; //player score        
        _gBricktkr = _greenBrickTicker;
        _greenStack  = _greenBrickTicker;
        _negativeBrickTick = _redTick;
        _blueStack = _blueCounter + _blueTick;
        _purpStack = _purpCounter + _purpTick;

        if (_resetScores >= 1)
        {
            ResetScore();
            _resetScores = 0;
        }
        if (_resetALL >= 1)
        {
            ResetALL();
            _resetALL = 0;
        }
  
        if (_penalty>=1)
        {
            Penalty();
        }

        //scoring logic    
        goodBrickTot = _greenTick - _negativeBrickTick;       
        totBrickCt = _greenTick + _negativeBrickTick;

        //scoring display
        BrickCounter.GetComponent<Text>().text = "Totals = " + totBrickCt;  //count all bricks
        PlayerScore.GetComponent<Text>().text = "Player Score: " + pcScore;
        Loops.GetComponent<Text>().text = "Loops = " + loopticker;  //count loopos, based on 10 bricks for each loop
        GBTick.GetComponent<Text>().text = "Green Brick = " + goodBrickTot; //counter for the green
        BBTick.GetComponent<Text>().text = "Red Brick = " + _negativeBrickTick;  //counter for the red  
      
    }


    //scoring collection logic
    void CoinCounter()
    {
        //scoring collection logic
        if (_greenBrickTicker >= _blueBrickGoals)
        {
            _greenBrickTicker = 0;
            _blBrktkr++;
            _blueCounter++;
            _maxScore++;
        }
        if (_blBrktkr >= _purpleBrickGoals)
        {
            _blBrktkr = 0;
            _prpBrktkr++;
            _purpCounter++;

            _maxScore++;
        }
        if (_prpBrktkr >= _LvlWGoals)
        {
            _prpBrktkr = 0;
            _maxScore++;
            loopticker++;
        }
    }

    void PollingData()
    {
        if (_pollLevel == 0)
        {
            //Debug.Log("Poll Level " + _pollLevel);
        }
        if (_pollLevel == 1)
        {
            Debug.Log("Poll Level " + _pollLevel);
        }
        if (_pollLevel == 2)
        {
            Debug.Log("Poll Level " + _pollLevel);
        }
        if (_pollLevel == 3)
        {
            Debug.Log("Poll Level " + _pollLevel);
        }
        if (_pollLevel == 4)
        {
            Debug.Log("Poll Level " + _pollLevel);
        }
        if (_pollLevel == 5)
        {
            Debug.Log("Poll Level " + _pollLevel);
        }
        if (_pollLevel == 6)
        {
            Debug.Log("Poll Level " + _pollLevel);
        }

    }

    void Penalty()
    {
        Debug.Log("Hit Spark + ");
        
        _penalty = 0;

    }

    public void ResetScore()
    {
        //reset all points to zero
        //loopticker = 0;
        _negativeBrickTick = 0;
        goodBrickTot = 0;
        //totBrickCt = 0;
        _redTick = 0;
        _blueStack=0;
        _purpStack = 0;
        _redTick = 0;
        _blueStack = 0;
        _purpStack = 0;
        _blueCounter = 0;
        _blueTick = 0;
        _purpCounter = 0;
        _purpTick = 0;
    }

    public void ResetALL()
    {
        //reset all points to zero
        loopticker = 0;
        _negativeBrickTick = 0;
        _greenTick = 0;
        goodBrickTot = 0;
        //totBrickCt = 0;
        _redTick = 0;
        _blueStack = 0;
        _purpStack=0;
        _blueCounter = 0;
        _blueTick = 0;
        _purpCounter = 0;
        _purpTick = 0;
    }

    public void ScoringSys()
    {
        /*

        */
        if (_greenBrickTicker <= 0)
        {
            _greenBrickTicker = 0;
        }
    }

}


/*    
    //use this to control song loop triggers
    public bool _goalsLoop1 = false;
    public bool _goalsLoop2 = false;
    public bool _goalsLoop3 = false;
    public bool _goalsLoop4 = false;
    public bool _goalsLoop5 = false;
    public bool _goalsLoop6 = false;
 *    
*/
