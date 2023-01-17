using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Forever;

public class LoopMachine : MonoBehaviour
{
    //this is the loop counter machine, used to fire off the audio tracks
    public static LoopMachine instance;


    //target coin collection goals 
    //which is half the trigger for song chunks
    //this is my audioBoxLength int target
    [SerializeField] public int _songLoopGoal_00; //multiplier for all unlocks
    [SerializeField] public int _songLoopGoal_01;
    [SerializeField] public int _songLoopGoal_02;
    [SerializeField] public int _songLoopGoal_03;
    [SerializeField] public int _songLoopGoal_04;
    [SerializeField] public int _songLoopGoal_05;
    [SerializeField] public int _songLoopGoal_06;
    [SerializeField] public int _songLoopGoal_07;
    [SerializeField] public int _songLoopGoal_08;
    [SerializeField] public int _songLoopGoal_09;


    //array of audio boxes
    public GameObject[] _audioBoxes;

    //audio controller, needs to trigger song loops at loop counts
    AudioSource audioSourceB;

    //public check box, comes from audioBox.WhoAmi()
    public static bool Array0Trig = false;
    public static bool Array1Trig = false;
    public static bool Array2Trig = false;
    public static bool Array3Trig = false;
    public static bool Array4Trig = false;
    public static bool Array5Trig = false;
    public static bool Array6Trig = false;
    public static bool Array7Trig = false;
    public static bool Array8Trig = false;
    public static bool Array9Trig = false;


    bool _array0 = false;
    bool _array1 = false;
    bool _array2 = false;
    bool _array3 = false;
    bool _array4 = false;
    bool _array5 = false;
    bool _array6 = false;
    bool _array7 = false;
    bool _array8 = false;
    bool _array9 = false;

    public static int greenCoinCollect; //from CollectBrck
    private int _greenCoin;
    private int _subLoopcounter;  //array triger subcounter
    [SerializeField] private int _subLoopTotals;
    [SerializeField] private int _ArrayCounter; //old purple coin

    public static int _pause = 0; //from Game Manager
    public static int _resetZero = 0; //from Game Manager
    bool _allStop = false;
    public static bool _lastLoopCheck = false;//from audioBox, trying to stop Loops
    public static bool resetLoop = false;
    bool _fireAudioLoops = false;

    //used to toggle next track of the song
    public static int _playNextTrack = 0; //from audioBox
    //public static int _isLoopFinished = 0; //from audioBox
    [SerializeField] private int _nextTrack = 0;

    private void Awake()
    {
        audioSourceB = GetComponent<AudioSource>();
        instance = this;
        _fireAudioLoops = true;
        //Invoke("DeactivateMe", audioSourceB.clip.length);
        SetToZero();
    }

    void Update()
    {
        CoinCounter();

        if (_fireAudioLoops)
        {
            FireAudioLoops();
        }

        if (_greenCoin >= _songLoopGoal_00)
        {
            ActivateAudioBox();
        }
        if (_pause >= 1)
        {
            PauseLoops();
        }
        if (_resetZero >= 1)
        {
            SetToZero();
            _resetZero = 0;
        }
        if (_lastLoopCheck)
        {
            PauseLoops();
            GameManager._noteQuota++;
        }

    }
    //AudioBox is the audio loop which player unlocks 
    public void ActivateAudioBox()
    {
        //first 8 notes - no loop
        if (_array0)
        {
            _audioBoxes[0].gameObject.SetActive(true);
            if (_playNextTrack == 1)
            {
                _nextTrack = 2;
            }
        }
        //2nd 8 notes - no loop
        if (Array1Trig && _nextTrack == 2)
        {
            _audioBoxes[1].gameObject.SetActive(true);
            if (_array1)
            {
                _nextTrack = 3;
                _audioBoxes[0].gameObject.SetActive(false);
            }
        }
        //fire Array 2
        if (Array2Trig && _nextTrack == 3)
        {
            _audioBoxes[2].gameObject.SetActive(true);
            _audioBoxes[1].gameObject.SetActive(false);
            if (_array2 && Array2Trig)
            {
                _nextTrack = 4;
            }
        }
        //fire Array 3
        if (Array3Trig && _nextTrack == 4)
        {
            _audioBoxes[3].gameObject.SetActive(true);
            _audioBoxes[2].gameObject.SetActive(false);
            if (_array3 && Array3Trig)
            {
                _nextTrack = 5;
            }
        }
        //fire Array 4
        if (Array4Trig && _nextTrack == 5)
        {
            _audioBoxes[4].gameObject.SetActive(true);
            _audioBoxes[3].gameObject.SetActive(false);

            if (_array4 && Array4Trig)
            {
                _nextTrack = 6;
            }

        }
        //fire Array 5
        if (Array5Trig && _nextTrack == 6)
        {
            _audioBoxes[5].gameObject.SetActive(true);
            _audioBoxes[4].gameObject.SetActive(false);
            
            if (_array5 && Array5Trig)
            {
                _nextTrack = 7;
            }
        }
        
        //fire Array 6
        if (Array6Trig && _nextTrack == 7)
        {
            _audioBoxes[6].gameObject.SetActive(true);
            _audioBoxes[5].gameObject.SetActive(false);

            if (_array6 && Array6Trig)
            {
                _nextTrack = 8;
            }
        }

        //fire Array 7
        if (Array7Trig && _nextTrack == 8)
        {
            _audioBoxes[7].gameObject.SetActive(true);
            _audioBoxes[6].gameObject.SetActive(false);

            if (_array7 && Array7Trig)
            {
                _nextTrack = 9;
            }
        }

        //fire Array 8
        if (Array8Trig && _nextTrack == 9)
        {
            _audioBoxes[8].gameObject.SetActive(true);
            _audioBoxes[7].gameObject.SetActive(false);

            if (_array8 && Array8Trig)
            {
                _nextTrack = 10;
            }
        }

        //fire Array 9
        if (Array9Trig && _nextTrack == 10)
        {
            _audioBoxes[9].gameObject.SetActive(true);
            _audioBoxes[8].gameObject.SetActive(false);

            if (_array9 && Array9Trig)
            {
                Debug.Log("Fnitio");
                //_nextTrack = 8;
            }
        }
    }

    public void PauseLoops()
    {
        audioBox._pause++;
    }

    void FireAudioLoops()
    {
        //to fire audio clilps 
        if (_greenCoin >= _songLoopGoal_00)
        {
            _array0 = true;
        }
        else
        {
            _array0 = false;
        }
        if (_subLoopTotals == _songLoopGoal_01)
        {
            _array1 = true;
        }
        if (_subLoopTotals == _songLoopGoal_02)
        {
            _array2 = true;
        }
        if (_subLoopTotals == _songLoopGoal_03)
        {
            _array3 = true;
        }
        if (_subLoopTotals == _songLoopGoal_04)
        {
            _array4 = true;
        }
        if (_subLoopTotals == _songLoopGoal_05)
        {
            _array5 = true;
        }
        if (_subLoopTotals == _songLoopGoal_06)
        {
            _array6 = true;
        }
        if (_subLoopTotals == _songLoopGoal_07)
        {
            _array7 = true;
        }
        if (_subLoopTotals == _songLoopGoal_08)
        {
            _array8 = true;
        }
        if (_subLoopTotals == _songLoopGoal_09)
        {
            _array9 = true;
        }
    }

    void CoinCounter()
    {

        if (greenCoinCollect == 1)
        {
            greenCoinCollect = 0;
            _greenCoin++;
            _subLoopcounter++;

        }
        if (_subLoopcounter >= _songLoopGoal_00)
        {
            _subLoopTotals++;
            _ArrayCounter++;
            //_purpCoinTotals++;
            _subLoopcounter = 0;
        }
        //if(_subLoopcounter >= _songLoopGoal_01)
    }

    public void SetToZero()
    {
        _lastLoopCheck = false;
        _greenCoin = 0;
        _subLoopcounter = 0;
        _subLoopTotals = 0; ;
        _ArrayCounter = 0;
        greenCoinCollect = 0;
        //this is a fucking for loop, learn it!
        _audioBoxes[0].gameObject.SetActive(false);
        _audioBoxes[1].gameObject.SetActive(false);
        _audioBoxes[2].gameObject.SetActive(false);
        _audioBoxes[3].gameObject.SetActive(false);
        _audioBoxes[4].gameObject.SetActive(false);
        _audioBoxes[5].gameObject.SetActive(false);
        _audioBoxes[6].gameObject.SetActive(false);
        _audioBoxes[7].gameObject.SetActive(false);
        _audioBoxes[8].gameObject.SetActive(false);
        _audioBoxes[9].gameObject.SetActive(false);
        Array0Trig = false;
        Array1Trig = false;
        Array2Trig = false;
        Array3Trig = false;
        Array4Trig = false;
        Array5Trig = false;
        Array7Trig = false;
        Array8Trig = false;
        Array9Trig = false;

        _array0 = false;
        _array1 = false;
        _array2 = false;
        _array3 = false;
        _array4 = false;
        _array5 = false;
        _array6 = false;
        _array7 = false;
        _array8 = false;
        _array9 = false;

    }
}