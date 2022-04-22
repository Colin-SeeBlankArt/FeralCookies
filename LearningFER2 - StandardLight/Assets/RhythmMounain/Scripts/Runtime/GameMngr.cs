using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMngr : MonoBehaviour
{
    public GameObject currentState;
    public static int StateTick;

    public Text timerText;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;

    }

    void Update()
    {
        /* timer
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
        */
        //state machine concepts
        //to learn: access the visual graph, set up methods for each step of the game

        currentState.GetComponent<Text>().text = "State = " + StateTick;

        if (StateTick == 1)
        {
            //boolean var (state is this state 1?, if so...)
                //play NB anmiation state, as indicated by NB during level build (start state value)
            Debug.Log("-- State Change 1 --");
            //if the value of the loop meter moves above ( a value not yet decided upon), then move to state 2         
        }

        if (StateTick == 4)
        {
            Debug.Log("-- State Change 2 --");
            //if the value of the loop meter moves above ( a value not yet decided upon), then move to state 3
            //if the value of the loop meter moves below ( a value not yet decided upon), then move to state 1
        }

        if (StateTick == 5)
        {
            Debug.Log("-- State Change 3 --");
            //if the value of the loop meter moves above ( a value not yet decided upon), then move to state 4 (outro?)
            //if the value of the loop meter moves below ( a value not yet decided upon), then move to state 2
        }
    }


}
