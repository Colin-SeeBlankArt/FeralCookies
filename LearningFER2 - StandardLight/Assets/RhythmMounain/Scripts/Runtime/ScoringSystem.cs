
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
            TotalGoodBricks = goodbrickTick,
            TotalBadBricks = badbrickTick,
            BlueStack = _blueStack,
            PurpStack = _purpStack
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
    //public Text textobject;
    public Text greenTick;
    public Text blueTick;
    public Text purpleTick;

    public Slider _greenSlider;
    public Slider _blueSlider;
    public Slider _purpleSlider;

    public static int brickTick;
    public static int goodbrickTick;  //this will be a positive impact on loop count
    public static int badbrickTick; //this will be a negative impact on loop count
    public static int _negativeBrickTick;
    public static int _penalty; //hit the bunny, get penalized
    public static int _blueStack; //blue coin stack
    public static int _purpStack; //purple coin stack

    public static int _loopTicker;  //actual score variable

    public int pcScore;

    public static int _resetScores = 0;

    int totBrickCt;
    int goodBrickTot;
    int badBrickTot;
    //int _negativeBrick;

    int loopticker;

    int _gBricktkr;
    int _blBrktkr;                          // Ticker for Purple Bricks 
    int _prpBrktkr;                         // Tcker for furture Brick colors

    public int _greenBrickGoals = 4;        // Trigger for + Blue Brick 
    public int _blueBrickGoals = 2;         // Trigger for + Purple Brick
    public int _purpleBrickGoals = 2;       // Trigger for future Brick colors

    public int _winLevel;

    private void Start()
    {
        //for scoring
        ResetScore();

        //for small sliders in UI
        _greenSlider.maxValue = _greenBrickGoals;
        _blueSlider.maxValue = _blueBrickGoals;
        _purpleSlider.maxValue = _purpleBrickGoals;
    }

    void Update()
    {
        if(_loopTicker <= 0)
        {
            _loopTicker = 0;
        }
 
        if(_resetScores >= 1)
        {
            ResetScore();
            _resetScores = 0;
        }

        pcScore = (totBrickCt);
        
        //slider logic
        _greenSlider.value = _loopTicker;
        greenTick.text = "" + _loopTicker;
        _blueSlider.value = _blBrktkr;
        blueTick.text = "" + _blBrktkr;
        _purpleSlider.value = _prpBrktkr;
        purpleTick.text = "" + _purpStack;

        //scoring logic
        goodBrickTot = (goodbrickTick - badBrickTot);
        badBrickTot = (_negativeBrickTick);
        totBrickCt = goodbrickTick + badbrickTick;

        //scoring display
        BrickCounter.GetComponent<Text>().text = "Totals = " + totBrickCt;  //count all bricks
        PlayerScore.GetComponent<Text>().text = "Player Score: " + pcScore;
        Loops.GetComponent<Text>().text = "Loops = " + loopticker;  //count loopos, based on 10 bricks for each loop
        GBTick.GetComponent<Text>().text = "Good Brick = " + goodBrickTot; //counter for the green
        BBTick.GetComponent<Text>().text = "Bad Brick = " + badBrickTot;  //counter for the red  

        if (loopticker >= _winLevel)
        {
            GameManager._noteQuota++;
        }

        //collection logic
        if (_loopTicker >= _greenBrickGoals)
        {
            Debug.Log("Green Tick");
            _loopTicker = 0;
            _blBrktkr++;
        }
        if (_blBrktkr >= _blueBrickGoals)
        {
            Debug.Log("Blue Tick");
            _blBrktkr = 0;
            _prpBrktkr++;
            loopticker++;
        }
        if (_prpBrktkr >= _purpleBrickGoals)
        {
            print("Purple Count");
            _prpBrktkr = 0;
        }
    }

    public void ResetScore()
    {
        //reset all points to zero
        loopticker = 0;
        _negativeBrickTick = 0;
        goodbrickTick = 0;
        goodBrickTot = 0;
        totBrickCt = 0;
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
