using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;

public class RovingBlocker : MonoBehaviour
{
    public static RovingBlocker instance;

    private LaneRunner runner;
    public int _currentLane;
    private float laneChangeSpd = 5f;
    private float elapsed;


    void Awake()
    {
        runner = GetComponent<LaneRunner>();
        instance = this;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= laneChangeSpd)
        {
            elapsed = 0f;
            ChangeLanes(2);
        }
    }

    public void ChangeLanes(int maxNum)
    {
        int randomValue = Random.Range(0, maxNum);
        if (randomValue == 1)
        {
            runner.lane++;
        }
        if (randomValue == 0)
        {
            runner.lane--;
        }
    }
}
