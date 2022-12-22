using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Dreamteck.Forever;

public class BunnyG : MonoBehaviour
{
    public static BunnyG instance;

    bool _destroyMe = false;
    //private float timerSpeed = 0.2f;
    private float destroyElapsed;

    private LaneRunner runner;
    public int _currentLane;
    private float laneChangeSpd = 2f;
    private float elapsed;
    public static int _bunnyToggle = 1;
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
            //invoke 1 second boost/2secondboost
            GoodBunny();
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
    public void GoodBunny()
    {
        _destroyMe = true;
        Debug.Log("BunnyGrn Speed Bonus");
    }
}

