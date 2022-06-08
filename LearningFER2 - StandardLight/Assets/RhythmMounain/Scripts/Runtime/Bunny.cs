using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Dreamteck.Forever;

public class Bunny : MonoBehaviour
{
    public static Bunny instance;

    private LaneRunner runner;
    public int _currentLane;
    private float laneChangeSpd = 3f;
    private float elapsed;
    private int randomValue;

    void Awake()
    {
        runner = GetComponent<LaneRunner>();
        instance = this;
    }

    void Update()
    {     
        elapsed += Time.deltaTime;
        if(elapsed >= laneChangeSpd)
        {
            elapsed = 0f;
            ChangeLanes(2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit the Player!");
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

//  I want to reduce the player's brick count 
//  I want to change colors, which defines
//      my brick count reduction
//      follow speed

//  I want animation states:
//      basic spin and scale
//      death
//  I want to spawn a message to the player that contact has been made, and brick count has changed, UI
