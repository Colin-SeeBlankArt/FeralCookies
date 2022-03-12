using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;


public class PlayerCtrl : MonoBehaviour
{
    LaneRunner runner;
    public static PlayerCtrl instance;
    //bool canBoost = true;
    float speed = 0f;
    float startSpeed = 0f;

    private void Awake()
    {
        runner = GetComponent<LaneRunner>();
        startSpeed = speed = runner.followSpeed;
        instance = this;       
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) runner.lane--;
        
        //animate character roll left, with ease in to start roll pos
        
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) runner.lane++;
     
        //animate character roll right, with ease in to start roll pos
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
        runner.followSpeed = speed;
        if (speed == 0f) EndScreen.Open();
    }

    public float GetSpeed()
    {
        return speed;
    }
}
