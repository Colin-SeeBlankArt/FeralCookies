using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSys2 : MonoBehaviour
{
    public static int greenCoinCollect; //from CollectBrck
    private int _greenCoin;
    private int _subLoopcounter;  //array triger subcounter
    [SerializeField] private int _subLoopTotals;
    [SerializeField] private int _ArrayCounter; //old purple coin


    [SerializeField]
    public int _array1LoopGoals;
    [SerializeField]
    public int _array2LoopGoals;
    [SerializeField]
    public int _array3LoopGoals;
    [SerializeField]
    public int _array4LoopGoals;
    [SerializeField]
    public int _array5LoopGoals;
    void Start()
    {
        SetToZero();
    }

    void Update()
    {
        CoinCounter();
        
        FireAudioLoops();
    }   

    void CoinCounter()
    {

        if (greenCoinCollect == 1)
        {
            greenCoinCollect = 0;
            _greenCoin ++;
            _subLoopcounter++;
            _subLoopTotals++;
        }
        if (_subLoopcounter >= _array1LoopGoals)
        {            
            _ArrayCounter++;
            //_purpCoinTotals++;
            _subLoopcounter = 0;           
        }


    }
    //to fire audio clilps 
    void FireAudioLoops()
    {
        //to fire audio clilps 
        //change these to reflect generic array calls, not specific loops
        if (_greenCoin >= 1)
        {
            LoopMachine._array1 = true;
        }
        else
        {
            LoopMachine._array1 = false;
        }
        if (_subLoopTotals >= _array1LoopGoals)
        {
            LoopMachine._array2 = true;
        }
        if (_ArrayCounter >= _array2LoopGoals)
        {
            LoopMachine._array3 = true;
        }
        if (_ArrayCounter >= _array3LoopGoals)
        {
            LoopMachine._array4 = true;
        }
        if (_ArrayCounter >= _array4LoopGoals)
        {
            LoopMachine._array5 = true;
        }
        if (_ArrayCounter >= _array5LoopGoals)
        {
            LoopMachine._array6 = true;
        }
    }

    public void SendWinToGamMgr()
    {
        //send message to Game Manager so song ends game. 
        //Maybe in the audioBox, as a boolean, so each level can be different
    }
    public void SetToZero()
    {
        _greenCoin = 0;
        _subLoopcounter = 0;
        _subLoopTotals = 0; ;
        _ArrayCounter = 0;
        greenCoinCollect = 0;

    }
}
