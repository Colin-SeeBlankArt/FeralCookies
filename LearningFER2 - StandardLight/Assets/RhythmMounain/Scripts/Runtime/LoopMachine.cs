using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Forever;

public class LoopMachine : MonoBehaviour
{
    //this is the loop counter machine, used to fire off the audio tracks
    public static LoopMachine instance;

    //comes from SoundBox (player collision)
    public static int _loopToggle = 0;


    [SerializeField] public int _array0LoopGoals;
    [SerializeField] public int _array1LoopGoals;
    [SerializeField] public int _array2LoopGoals;
    [SerializeField] public int _array3LoopGoals;
    [SerializeField] public int _array4LoopGoals;
    [SerializeField] public int _array5LoopGoals;
    [SerializeField] public int _array6LoopGoals;

    //array of audio boxes
    public GameObject[] _audioBoxes; 
    
    //audio controller, needs to trigger song loops at loop counts
    AudioSource audioSourceB;

    public int musicPause = 0;
    public bool startPoint;

    public static bool Array0Trig = false;
    public static bool Array1Trig = false;
    public static bool Array2Trig = false;
    public static bool Array3Trig = false;
    public static bool Array4Trig = false;
    public static bool Array5Trig = false;
    public static bool Array6Trig = false;

    bool _array0 = false;
    bool _array1 = false;
    bool _array2 = false;
    bool _array3 = false;
    bool _array4 = false;
    bool _array5 = false;
    bool _array6 = false;

    public static int greenCoinCollect; //from CollectBrck
    private int _greenCoin;
    private int _subLoopcounter;  //array triger subcounter
    [SerializeField] private int _subLoopTotals;
    [SerializeField] private int _ArrayCounter; //old purple coin

    public static int _pause = 0; //from Game Manager
    public static int _resetZero = 0; //from Game Manager
    public bool _allStop = false;
    public static bool resetLoop = false;
    bool _fireAudioLoops = false;

    //used to toggle next track of the song
    public static int _playNextTrack = 0; //from audioBox
    public static int _isLoopFinished = 0; //from audioBox
    [SerializeField] private int _nextTrack=0;

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
        
        if(_fireAudioLoops)
        {
            FireAudioLoops();
        }

        if (_greenCoin >= _array0LoopGoals)
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

        if (_loopToggle == 1)
        {            
            //_array1 = true;
            _loopToggle = 0;
        }
    }
    //AudioBox is the audio loop which player unlocks 
    public void ActivateAudioBox()
    {
        //first 8 notes - no loop
        if (_array0)
        {            
            _audioBoxes[0].gameObject.SetActive(true);
            if (_playNextTrack ==1)
            {
                _nextTrack = 2;
                Debug.Log("Song loop 0");
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
                Debug.Log("Song loop 1");
                //_array1=false;
            }
        }
         //fire Array 2
        if (Array2Trig  && _nextTrack== 3)
        {          
            _audioBoxes[2].gameObject.SetActive(true);
            _audioBoxes[1].gameObject.SetActive(false);
            if (_array2 && Array2Trig)
            {
                _nextTrack = 4;
                Debug.Log("Song loop 2");             
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
                Debug.Log("Song loop 3 - LoopHit");
                
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
                Debug.Log("Song loop 4 LoopHit");
            }           

        }
        //fire Array 5
        if (Array5Trig && _nextTrack == 6)
        {
            _audioBoxes[5].gameObject.SetActive(true);
            _audioBoxes[4].gameObject.SetActive(false);
            Debug.Log("Song loop 5");
        }
    }

    public void PauseLoops()
    {
        audioBox._pause++;
    }

    void FireAudioLoops()
    {
        //to fire audio clilps 
        //change these to reflect generic array calls, not specific loops
        if (_greenCoin >= _array0LoopGoals)
        {
            _array0 = true;
        }
        else
        {
            _array1 = false;
        }
        if (_subLoopTotals == _array1LoopGoals)
        {
            _array1 = true;
        }
        if (_subLoopTotals == _array2LoopGoals)
        {
            _array2 = true;
        }
        if (_subLoopTotals == _array3LoopGoals)
        {
            _array3 = true;
        }
        if (_subLoopTotals == _array4LoopGoals)
        {
            _array4 = true;
        }
        if (_subLoopTotals == _array5LoopGoals)
        {
            _array5 = true;
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
        if (_subLoopcounter >= _array0LoopGoals)
        {
            _subLoopTotals++;
            _ArrayCounter++;
            //_purpCoinTotals++;
            _subLoopcounter = 0;
        }
    }

    public void SetToZero()
    {
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
        Array0Trig = false;
        Array1Trig = false;
        Array2Trig = false;
        Array3Trig = false;
        Array4Trig = false;
        Array5Trig = false;
        Array6Trig = false;
        _array0 = false;
        _array1 = false;
        _array2 = false;
        _array3 = false;
        _array4 = false;
        _array5 = false;
        _array6 = false;

    }
}
