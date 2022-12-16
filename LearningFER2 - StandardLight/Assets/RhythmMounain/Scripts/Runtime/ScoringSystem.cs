using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
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
        };

        SaveManager.Instance.SaveData("SessionData", sessionData);
        AnalyticsManager.SaveDataAsync("SessionData", sessionData);
    }

    public GameObject BrickCounter;
    public GameObject PlayerScore;
    public GameObject Loops;
    public GameObject GBTick;
    public GameObject BBTick;

    //UI Element which activates Buttons for Songs
    public GameObject LoopLists;

    public Text greenTick;
    public Text blueTick;
    public Text purpleTick;

    public Slider _greenSlider;
    public Slider _blueSlider;
    public Slider _purpleSlider;

    public static int _greenBrickTicker;  //actual score variable

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

    public static int _resetScores = 0; //GAmeManger, Reset Level
    public static int _resetALL = 0; //GAmeManger, Reset All counters

    int totBrickCt;
    int goodBrickTot;

    int loopticker;
    int _gBricktkr;
    int _blBrktkr;                          // Ticker for Purple Bricks 
    int _blueCounter;
    int _prpBrktkr;                         // Tcker for furture Brick colors
    int _purpCounter;
 
    int _loopTicker;
    int _loopCount;
    int _loopGoals;

    public int _blueBrickGoals = 4;        // Trigger for + Blue Brick 
    public int _purpleBrickGoals = 2;         // Trigger for + Purple Brick
    public int _LvlWGoals = 2;       // Trigger for Level Winning
    
    [SerializeField]
    public int _winLevel;

    private void Start()
    {
        ResetALL();
        _loopGoals = _LvlWGoals;
        _greenSlider.maxValue = _blueBrickGoals;
        _blueSlider.maxValue = _purpleBrickGoals;
        _purpleSlider.maxValue = _LvlWGoals;    
        }

    void Update()
    {
        FireAudioLoops();
        CoinCounter();

        brickTick = brickTick + totBrickCt;
        
        pcScore = totBrickCt + _maxScore + _blueTick + _purpTick; //player score
        
        //seting to zeros for scoretable
        if (_greenBrickTicker <= 0)
        {
            _greenBrickTicker = 0;
        }
        if (goodBrickTot <= 0)
        {
            goodBrickTot = 0;
        }
        if (_greenTick <= 0)
        {
            _greenTick = 0;
        }
        if (_gBricktkr <= 0)
        {
            _gBricktkr = 0;
        }

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
        if (loopticker >= _winLevel)
        {
            GameManager._noteQuota++;
        }
        if (_penalty>=1)
        {
            _greenBrickTicker = _greenBrickTicker/2;
            _greenTick = 0;
            Debug.Log("Hit Spark + ");
            _penalty = 0;
        }

        _greenSlider.value = _gBricktkr; 
        greenTick.text = "" + _greenTick;
        _blueSlider.value = _blBrktkr;
        blueTick.text = "" + _blueStack;
        _purpleSlider.value = _prpBrktkr;
        purpleTick.text = "" + _purpStack;

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
    //to fire audio clilps 
    void FireAudioLoops()
    {
        //to fire audio clilps 
        if (/*_greenStack*/ goodBrickTot >= 1)
        {
            SoundBox._bassA = true;
        }
        else
        {
            SoundBox._bassA = false;
        }
        if (_blueCounter >= 1)
        {
            SoundBox._keysA1 = true;
        }
        if (_blueCounter >= 4)
        {
            SoundBox._keysA2 = true;
        }
    }

    //scoring collection logic
    void CoinCounter()
    {
        //scoring collection logic
        if (_greenBrickTicker >= _blueBrickGoals)
        {
            Debug.Log("Blue Tick");
            _greenBrickTicker = 0;
            _blBrktkr++;
            _blueCounter++;
            _maxScore++;
        }
        if (_blBrktkr >= _purpleBrickGoals)
        {
            Debug.Log("Purple Tick");
            _blBrktkr = 0;
            _prpBrktkr++;
            _purpCounter++;

            _maxScore++;
        }
        if (_prpBrktkr >= _LvlWGoals)
        {
            print("Level Loop Tick");
            _prpBrktkr = 0;
            _maxScore++;
            loopticker++;
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

    public void a()//trigger the winLevel in GameManager
    {
        GameManager._noteQuota++;
    }
}


/*    

 *    
*/
