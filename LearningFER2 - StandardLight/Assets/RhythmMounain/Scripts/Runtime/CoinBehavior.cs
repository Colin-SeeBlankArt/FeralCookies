using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public bool _goodBrick, _badBrick;

    private float timerSpeed = 1;
    private float lastTimestamp;

    private void OnTriggerEnter()
    {
        BrickCounter();
        DestroyMe();
    }

    public void BrickCounter()
    {
        ScoreSys.goodbrickTick += 1;
        Debug.Log("Green Brick") ;

    }

    public void DestroyMe()
    {
        if (Time.time - lastTimestamp >= timerSpeed)
        {
            lastTimestamp = Time.time;
            Destroy(gameObject);
        }
    }
}
