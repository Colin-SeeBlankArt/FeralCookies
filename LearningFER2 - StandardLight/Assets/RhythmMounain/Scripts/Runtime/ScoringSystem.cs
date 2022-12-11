using System;
using Dreamteck;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public static void RecordResults()
    {
        var gameData = SaveManager.Instance.LoadDataBlocking("GameData", new GameSaveData());

        var sessionData = new GameSessionData()
        {
            TimeCreated = DateTime.UtcNow,
            TotalBricks = brickTick,
            //TotalGoodBricks = goodbrickTick,
            //TotalBadBricks = badbrickTick,
            //BlueStack = _blueStack,
            //PurpStack = _purpStack
        };

        gameData.SessionData ??= Array.Empty<GameSessionData>();
        ArrayUtility.Add(ref gameData.SessionData, sessionData);

        SaveManager.Instance.SaveData("GameData", gameData);
    }

    public GameObject BrickCounter;
    public GameObject PlayerScore;
    public GameObject Loops;
    public GameObject GBTick;
    public GameObject BBTick;

    public Text greenTick;
    public Text blueTick;
    public Text purpleTick;
    public Text loopTick;

    public Slider _greenSlider;
    public Slider _blueSlider;
    public Slider _purpleSlider;
    public Slider _loopSlider;

    public static int _greenBrickTicker;  //actual score variable

    public static int brickTick;
    public static int _greenTick;   //this will be a positive impact on loop count
    public static int _redTick;     //this will be a negative impact on loop count
    public static int _purpTick;
    public static int _blueTick;

    public static int _greenStack;  //green collection
    int _negativeBrickTick;
    
    public static int _penalty; //hit the bunny, get penalized
    
    int _blueStack; //blue coin stack
    int _purpStack; //purple coin stack

    public int pcScore;

    public static int _resetScores = 0; //GAmeManger, Reset Level
    public static int _resetALL = 0; //GAmeManger, Reset All counters

    int totBrickCt;
    int goodBrickTot;
    //int badBrickTot;
    //int _negativeBrick;

    int loopticker;

    int _gBricktkr;
    
    int _blBrktkr;                          // Ticker for Purple Bricks 
    int _blueCounter;
    int _prpBrktkr;                         // Tcker for furture Brick colors
    int _purpCounter;
    int _loopTicker;
    int _loopCount;

    public int _greenBrickGoals = 4;        // Trigger for + Blue Brick 
    public int _blueBrickGoals = 2;         // Trigger for + Purple Brick
    public int _purpleBrickGoals = 2;       // Trigger for future Brick colors
    int _loopGoals;
    [SerializeField]
    public int _winLevel;

    private void Start()
    {
        ResetALL();
        _loopGoals = _purpleBrickGoals;
        //slider values for visual rep of loop count
        _greenSlider.maxValue = _greenBrickGoals;
        _blueSlider.maxValue = _blueBrickGoals;
        _purpleSlider.maxValue = _purpleBrickGoals;

        _loopSlider.maxValue = _winLevel;        

        }

    void Update()
    {
         brickTick = brickTick + totBrickCt;
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
            _greenTick = 0;
            Debug.Log("Hit Spark + ");
            _penalty = 0;
        }

        //pcScore = totBrickCt;
        
        //slider UI
        _greenSlider.value = _gBricktkr; 
        greenTick.text = "" + _greenTick;
        _blueSlider.value = _blBrktkr;
        blueTick.text = "" + _blueStack;
        _purpleSlider.value = _prpBrktkr;
        purpleTick.text = "" + _purpStack;
        _loopSlider.value = _loopTicker;
        loopTick.text = "" + _winLevel;

        //scoring logic
        goodBrickTot = _greenTick - _negativeBrickTick;       
        totBrickCt = _greenTick + _negativeBrickTick;

        //scoring display
        BrickCounter.GetComponent<Text>().text = "Totals = " + totBrickCt;  //count all bricks
        PlayerScore.GetComponent<Text>().text = "Player Score: " + pcScore;
        Loops.GetComponent<Text>().text = "Loops = " + loopticker;  //count loopos, based on 10 bricks for each loop
        GBTick.GetComponent<Text>().text = "Green Brick = " + goodBrickTot; //counter for the green
        BBTick.GetComponent<Text>().text = "Red Brick = " + _negativeBrickTick;  //counter for the red  
        
        //scoring collection logic
        if (_greenBrickTicker >= _greenBrickGoals)
        {
            Debug.Log("Green Tick");
            _greenBrickTicker = 0;          
            _blBrktkr++;
            _blueCounter++;
            pcScore++;
        }
        if (_blBrktkr >= _blueBrickGoals)
        {
            Debug.Log("Blue Tick");
            _blBrktkr = 0;
            _prpBrktkr++;
            _purpCounter++;
            loopticker++;
            pcScore++;
        }
        if (_prpBrktkr >= _purpleBrickGoals)
        {
            print("Purple Tick");
            _prpBrktkr = 0;
            
            pcScore++;
        }

        if (_greenBrickTicker <= 0)
        {
            _greenBrickTicker = 0;
        }
        if (goodBrickTot <= 0)
        {
            goodBrickTot = 0;
        }

        //to fire audio clilps 
        if (_greenStack >= 1)
        {
            SoundBox._bassA = true;
        }
        
        if(_blueCounter >= 1)
        {
            SoundBox._keysA1 = true;
        }
        if(_blueCounter >= 4)
        {
            SoundBox._keysB1 = true;
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
    }

    public void ResetALL()
    {
        //reset all points to zero
        loopticker = 0;
        _negativeBrickTick = 0;
        _greenTick = 0;
        goodBrickTot = 0;
        totBrickCt = 0;
        _redTick = 0;
        _blueStack = 0;
        _purpStack=0;
    }

    public void a()//trigger the winLevel in GameManager
    {
        GameManager._noteQuota++;
    }

}


/*    
 *         
 *  
 *  void LoopCounter()
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
