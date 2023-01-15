using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioBox : MonoBehaviour
{
    AudioSource audioSource;

    public static audioBox instance;
    public static int _pause = 0;
    public static bool _loop = false;
    public bool _isFinalTrack = false;

    public bool _array0Trig = false;
    public bool _array1Trig = false;
    public bool _array2Trig = false;
    public bool _array3Trig = false;
    public bool _array4Trig = false;
    public bool _array5Trig = false;
    public bool _array6Trig = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        instance = this;
    }

    void Update()
    {
        EndPlaying();


        if (_pause == 1)
        {
            audioSource.Pause();
        }
        else { audioSource.UnPause(); }

        if (_loop)
        {
            audioSource.loop = true;
        }
        //else { EndPlaying(); }
    }

    public void EndPlaying()
    {
        if (!audioSource.isPlaying)
        {
            LoopMachine._playNextTrack = 1;

            if (_isFinalTrack)
            {
                LastLoopCheck();
            }
            if (LoopMachine._lastLoopCheck == false)
            {
                WhoAmI();
            }
        }

    }

    public void LastLoopCheck()
    {
        LoopMachine._lastLoopCheck = true;
        audioSource.Pause();
    }
    //fires to the LoopMachine to launch next loop to play, based on Array order
    public void WhoAmI()
    {
        //if I am array 1, then array 2 is true, if I am array 2, then array3 true
        if (_array0Trig)
        {
            LoopMachine.Array1Trig = true;
        }
        if (_array1Trig)
        {
            LoopMachine.Array2Trig = true; //nest looping Bass with this          
        }
        if (_array2Trig)
        {
            LoopMachine.Array3Trig = true;
        }
        if (_array3Trig)
        {
            LoopMachine.Array4Trig = true;
        }
        if (_array4Trig)
        {
            LoopMachine.Array5Trig = true;

        }
        if (_array5Trig)
        {
            LoopMachine.Array6Trig = true;
        }
        if (_array6Trig)
        {
            LoopMachine.Array6Trig = true;
        }
    }

}