using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Dreamteck.Forever;

public class Bunny : MonoBehaviour
{
    public static Bunny instance;

    bool _destroyMe = false;
    //private float timerSpeed = 0.2f;
    private float destroyElapsed;

    private LaneRunner runner;
    public int _currentLane;
    private float laneChangeSpd = 3f;
    private float elapsed;

    public static int _bunnyToggle = 0;

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
        if (_destroyMe)  //bool to say kill the coin
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

                BadBunny();


            _destroyMe = true;
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
    public void BadBunny()
    {
        ScoringSystem._penalty++;
        Debug.Log("BunnyRed Speed Minus");
    }
    
}

