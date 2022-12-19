using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSys2 : MonoBehaviour
{
    public static int greenCoinCollect;
    private int _greenCoin;

    private int _redCoin;
    private int _blueCoin;
    private int _purpCoin;

    [SerializeField]
    public int _blueLoopGoals;
    [SerializeField]
    public int _redLoopGoals;
    [SerializeField]
    public int _purpLoopGoals;

    [SerializeField]
    public int _curCount;

    void Update()
    {
        CoinCounter();
    }   

    void CoinCounter()
    {
        if (greenCoinCollect == 1)
        {
            greenCoinCollect = 0;
            _blueCoin++;
            Debug.Log("_greenCoin +1");
        }
        if (_blueCoin >= _blueLoopGoals)
        {
            _purpCoin++;
            _blueCoin = 0;
            Debug.Log("_blueCoin +1");
        }
        if(_purpCoin >= _purpLoopGoals)
        {
            Debug.Log("_purpCoin +1");
            _curCount++;
            _purpCoin=0;
        }
    }

}
