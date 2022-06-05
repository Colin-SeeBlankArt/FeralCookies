using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Dreamteck.Forever;

public class Bunny : MonoBehaviour
{
    public static Bunny instance;

    //  I want to reduce the player's brick count 
    //  I want to change colors, which defines
    //      my brick count reduction
    //      follow speed
    //  I want to switch between 6 lanes, random, one lane at a time

    private LaneRunner runner;

    public int _currentLane;

    //  I want to spawn randomly between 4 seconds and 8 seconds

    private float laneChangeSpd = 3f;
    private float elapsed;
    private int randomValue;

    //  I want animation states:
    //      basic spin and scale
    //      death
    //  I want to spawn a message to the player that contact has been made, and brick count has changed, UI



    void Awake()
    {
        runner = GetComponent<LaneRunner>();
        //_currentLane = runner.lane;

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        elapsed += Time.deltaTime;
        if(elapsed >= laneChangeSpd)
        {
            elapsed = 0f;
            ChangeLanes(2);

        }

    }

    public void ChangeLanes(int maxNum)
    {
        int randomValue = Random.Range(0, maxNum);
        if(randomValue == 1)
        {
            runner.lane++;           
        }
        if (randomValue == 0)
        {
            runner.lane--;
        }

    }
}
