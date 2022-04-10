using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMngr : MonoBehaviour
{
    public GameObject currentState;
    public static int StateTick;

    void Update()
    {
        /*if Pause is true:
            if ^Pause Button* is pressed, game time set to 0.0
            Open/Activate Pause Screen UI Set
        */

        currentState.GetComponent<Text>().text = "State = " + StateTick;

        if (StateTick == 1)
        {
            Debug.Log("-- State Change 1 --");
           
        }
        if (StateTick == 3)
        {
            Debug.Log("-- State Change 2 --");

        }
        if (StateTick == 4)
        {
            Debug.Log("-- State Change 3 --");

        }
    }
}
