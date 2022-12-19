using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Forever;

public class LoopMachine : MonoBehaviour
{
    public static LoopMachine instance;

    //this is the loop counter machine, used to fire off the audio tracks
    public static int _loopToggle = 0;
    public GameObject BassAGameObject;

    public GameObject[] _audioBoxes; //array of audio boxes
    
    [SerializeField]
    private int _loopCountA; //first loop level in a level
    [SerializeField]
    private int _loopCtr;

    //audio controller, needs to trigger song loops at loop counts
    AudioSource audioSourceB;

    public int musicPause = 0;
    public bool startPoint;
    public bool bassATrig;
    public bool keysA1Ttrig;
    public bool keysA2Ttrig;
    public bool keysB1Trig;
    public static int _pause = 0; //from Game Manager
    public bool _allStop = false;
    bool resetLoop = false;

    //these come from ScoringSystem
    public static bool _bassA = false;
    public static bool _keysA1 = false;
    public static bool _keysA2 = false;
    public static bool _keysB1 = false;
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
            bassATrig = true;
        }
    }

    void PlayingIsTrue()
    {
        //wait the time of the length of the loop to move to the next step
        if (!audioSourceB.isPlaying)
        {
            //wait the time of the length of the loop to move to the next step
            Debug.Log("Audio stopped");
            gameObject.SetActive(false);
        }
    }
    public void ActivatePlayBox()
    {
    
        if (_bassA)
        {
            _audioBoxes[0].gameObject.SetActive(true);
            keysA1Ttrig = true;
            if (_bassA && bassATrig)
            {
                audioBox._loop = true;
            }
            
        }

        if (keysA1Ttrig && _keysA1)
        {
            Debug.Log("Keys A plays");
            _audioBoxes[1].gameObject.SetActive(true);
            audioBox._loop = false;
        }
        //fire Keys A2
        if (keysA2Ttrig && _keysA2)
        {
            _audioBoxes[2].gameObject.SetActive(true);
            audioBox._loop = false;
            Debug.Log("Keys A2 plays");
        }
        //fire Keys B
        if (keysB1Trig && _keysB1)
        {
            _audioBoxes[3].gameObject.SetActive(true);
            audioBox._loop = false;
            Debug.Log("Keys B plays");
        }
        
    }

    public void PauseLoops()
    {
        audioBox._pause++;
    }


}
