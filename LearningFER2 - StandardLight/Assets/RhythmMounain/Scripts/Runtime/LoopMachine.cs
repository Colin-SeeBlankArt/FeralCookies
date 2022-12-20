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

    //array of audio boxes
    public GameObject[] _audioBoxes; 
    
    //audio controller, needs to trigger song loops at loop counts
    AudioSource audioSourceB;

    public int musicPause = 0;
    public bool startPoint;

    [SerializeField] private bool Array1Trig;
    [SerializeField] private bool Array2Trig;
    [SerializeField] private bool Array3Trig;
    [SerializeField] private bool Array4Trig;
    [SerializeField] private bool Array5Trig;
    [SerializeField] private bool Array6Trig;

    public static int _pause = 0; //from Game Manager
    public bool _allStop = false;
    public static bool resetLoop = false;

    //these come from ScoringSystem
    public static bool _array1 = false;
    public static bool _array2 = false;
    public static bool _array3 = false;
    public static bool _array4 = false;
    public static bool _array5 = false;
    public static bool _array6 = false;

    //used to toggle next track of the song
    public static bool _playNextTrack = false; //from audioBox
    [SerializeField] private int _nextTrack=0;

    private void Awake()
    {
        audioSourceB = GetComponent<AudioSource>();
        instance = this;
        //Invoke("DeactivateMe", audioSourceB.clip.length);
    }
    private void Start()
    {
    }
    void Update()
    {

        
        if (_pause >= 1)
        {
            PauseLoops();
        }

        if (_loopToggle >= 1)
        {
            ActivatePlayBox();
            _array1 = true;
        }
    }
    public void ActivatePlayBox()
    {
        //fire Array A
            //first 8 notes - no loop
        if (_array1)
        {
            _audioBoxes[0].gameObject.SetActive(true);
            Array2Trig = true;
            if (_array1 && _playNextTrack)
            {
                _nextTrack = 2;
                _playNextTrack = false;
                Debug.Log("Array0");
            }
        }
        //fire Array B
            //first 8 notes - no loop
        if (Array2Trig && _nextTrack==2)
        {            
            _audioBoxes[1].gameObject.SetActive(true);

            if (_array2 && _playNextTrack)
            {
                _nextTrack = 3;
                _playNextTrack = false;
                Debug.Log("Array1");
                Array3Trig = true;               
            }
        }
        //fire Array C
            //loop bass A
        if (Array3Trig && _nextTrack == 3)
        {
            _audioBoxes[2].gameObject.SetActive(true);
            if (_array3)
            {
                _nextTrack = 4;
                _playNextTrack = false;
                Debug.Log("Array3");
                Array4Trig = true;
            }

        }
        //fire Array D
        if (Array4Trig && _nextTrack == 4)
        {
            _audioBoxes[3].gameObject.SetActive(true);
            audioBox._loop = false;
            if (_array4)
            {
                _nextTrack = 4;
                _playNextTrack = false;
                Debug.Log("Array4");
                Array5Trig = true;
            }
        }
        //fire Array E
        if (Array5Trig && _nextTrack == 5)
        {
            _audioBoxes[4].gameObject.SetActive(true);
            audioBox._loop = false;
            Debug.Log("Array E plays");
        }
        //fire Array F
        if (Array6Trig && _nextTrack == 6)
        {
            _audioBoxes[5].gameObject.SetActive(true);
            audioBox._loop = false;
            Debug.Log("Array F plays");
        }
    }

    public void PauseLoops()
    {
        audioBox._pause++;
    }


}
