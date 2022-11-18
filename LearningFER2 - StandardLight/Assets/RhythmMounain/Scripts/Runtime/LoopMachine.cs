using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMachine : MonoBehaviour
{
    //this is the loop counter machine, used to fire off the audio tracks
    //this will take in from CollectBricks the TickerCounter
    static public int _loopTicker =0; //comes from from CollectBrick
    static public int _resetLoopCount = 0; //comes from Outside (single source)

    int _loopCtr;  //inherits _loopTicker 
    int _loopCount; //Loop counter, want to reduce count (rule)
    int _CurLoop; //Holds Current Loop Designation
    int _loopAdvance;
    private void Start()
    {
        
    }

    private void Update()
    {
        _loopCtr = _loopTicker;
        Debug.Log($"LoopCounter {_loopCtr}");

        if (_resetLoopCount >= 1)
        {
            LoopReset();
        }
    }

    public void LoopCount()
    {
        if (_loopTicker >= _loopAdvance)
        {
            _CurLoop++;
        }
    }

    public void LoopReset()
    {
        _loopCtr = 0;

    }
}
