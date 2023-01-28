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
            //TimeCreated = DateTime.UtcNow,
            TotalBricks = brickTick,
            PlayerScore = pcScore,
            GreenStack = _greenStack,
            RedStack = _redStack,
            BlueStack = _blueStack,
            PurpStack = _purpStack,
            RdSparkTot = _rBunny,
            GrnSparkTot = _gBunny,

            /*PollQuest_[Loop] = (Polls),
             * TimeElapsed = timeElapsed,
             * Poll_1 = _pollLevel_1,
             */
        };

        SaveManager.Instance.SaveData("SessionData", sessionData);
        AnalyticsManager.SaveDataAsync("SessionData", sessionData);
    }

    //text of data
    public GameObject BrickCounter;
    public GameObject PlayerScore;
    public GameObject GreenCoincount;
    public GameObject BlueCoinCount;
    public GameObject PurpCoincount;
    public GameObject RedCoinTick;

    ///// Major Counter
    //actual score variable
    public static int _greenBrickTicker;

    ////Poll Values
    public static int _pollLevel_1 = 0; //values from Poll Pop Up
    public GameObject PollsBase;    //Poll Menu panel
    bool _isFinalLevel=false;

    ////for Data Capture
    public static int _greenStack;  //green collection
    public static int _blueStack; //blue coin stack
    public static int _purpStack; //purple coin stack
    public static int _redStack;

    // coming from CollectBrick
    public static int brickTick;
    public static int _greenTick;   //this will be a positive impact on loop count
    public static int _redTick;     //this will be a negative impact on loop count
    public static int _purpTick;    //unlocks future items
    public static int _blueTick;    //unlocks future items 

    int _negativeBrickTick;
    
    public static int _rBunny; //hit the bunny, get penalized
    public static int _gBunny;
    public static int _penalty;

    public static int pcScore;
    int _maxScore;

    public static int _resetScores = 0; //GameManger, Reset Level
    public static int _resetALL = 0; //GameManger, Reset All counters

    //UI for display of BlueCounter
    public GameObject BlueBlockGoalUI;

    int totBrickCt;
    int goodBrickTot;

    //int loopticker;
    int Purseticker;
    int _gBricktkr; //green coin purse
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
        _redStack = _negativeBrickTick = (_redTick*2);
        _blueStack = _blueTick;
        _purpStack = _purpTick;
        CoinCounter();
        PollingData_A();
        ScoringSys();

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
  


        //scoring display
        //count all bricks
        BrickCounter.GetComponent<Text>().text = "Totals = " + totBrickCt;  
        PlayerScore.GetComponent<Text>().text = "Player Score: " + pcScore;

        //counter for the green
        GreenCoincount.GetComponent<Text>().text = "Green Coins = " + _gBricktkr;

        BlueCoinCount.GetComponent<Text>().text = "Blue Coins = " + _blueStack;

        PurpCoincount.GetComponent<Text>().text = "Purple Coins = " + _purpStack;
        //counter for the red
        RedCoinTick.GetComponent<Text>().text = "Red Brick = " + _negativeBrickTick;    
    }


    //scoring collection logic
    void CoinCounter()
    {
        //scoring collection logic
        
        
        if (_greenBrickTicker >= _blueBrickGoals)
        {
            _greenBrickTicker = 0;
            //_gBricktkr++;
            _blBrktkr++;
            _blueCounter++;
            _maxScore++;
        }
        if (_blBrktkr >= _purpleBrickGoals)
        {
            _blBrktkr = 0;
            _prpBrktkr++;
            _purpCounter++; //loops unlocks

            _maxScore++;
        }
        if (_prpBrktkr >= _LvlWGoals)
        {
            _prpBrktkr = 0;
            _maxScore=_maxScore + 2;
            Purseticker++;
        }
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
        _blueCounter = 0;
        _blueTick = 0;
        _purpCounter = 0;
        _purpTick = 0;
    }

    public void ResetALL()
    {
        //reset all points to zero
        Purseticker = 0;
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
        pcScore = _maxScore;
        totBrickCt = _greenStack + _purpStack + _blueStack + _negativeBrickTick;
        
        //green brick count and display in UI
        _gBricktkr = _greenStack - _negativeBrickTick;
        brickTick = totBrickCt;

        if (_gBricktkr <= 0)
        {
            _gBricktkr = 0;
        }
        
        //collection of coin pick ups
        _maxScore = (_greenStack + (_purpStack*3) + (_blueStack*2) + (_gBunny*4));
        if (_penalty >= 1)
        {
            _blueStack = _blueStack - 2;
            _penalty = 0;
        }
    }

    void PollingData_A()
    {
        if (_pollLevel_1 == 0)
        {
            //this is labeled as "Choose One"
        }
        if (_pollLevel_1 == 1)
        {
            Debug.Log("Poll Level " + _pollLevel_1);
        }
        if (_pollLevel_1 == 2)
        {
            Debug.Log("Poll Level " + _pollLevel_1);
        }
        if (_pollLevel_1 == 3)
        {
            Debug.Log("Poll Level " + _pollLevel_1);
        }
        if (_pollLevel_1 == 4)
        {
            Debug.Log("Poll Level " + _pollLevel_1);
        }
        if (_pollLevel_1 == 5)
        {
            Debug.Log("Poll Level " + _pollLevel_1);
        }
        if (_pollLevel_1 == 6)
        {
            Debug.Log("Poll Level " + _pollLevel_1);
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
