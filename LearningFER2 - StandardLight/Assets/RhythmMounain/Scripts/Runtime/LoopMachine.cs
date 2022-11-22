using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Forever;

public class LoopMachine : MonoBehaviour
{
    //this is the loop counter machine, used to fire off the audio tracks

    [SerializeField]
    private int _loopCountA; //first loop level in a level
    [SerializeField]
    private int _loopCtr;

    static public int _loopTicker =0; //comes from from Scoring
    static public int _resetLoopCount = 0; //comes from SoundBox

    private LaneRunner _levelControl; 

    //audio controller, needs to trigger song loops at loop counts
    //

    int _CurLoop; //Holds Current Loop Designation
    
    int _loopAdvance;
    private void Awake()
    {
        _levelControl = GetComponent<LaneRunner>();
    }

    void Update()
    {
        LoopCount();

    }

    public void LoopCount()
    {
        if (_loopTicker >= _loopCountA)
        {
            _CurLoop++;
            _loopTicker = 0;
            Debug.Log("Loop Count " + _CurLoop);
        }
    } //loop counter

     
}
