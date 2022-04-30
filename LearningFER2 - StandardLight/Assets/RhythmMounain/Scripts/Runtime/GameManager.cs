using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public GameObject otherGameObject;  
   // private CollectBrick collectBrick;

    public GameObject currentState;
    public static int StateTick;
    public int _currentState;

    void Awaket()
    {
        //collectBrick = GetComponent<CollectBrick>();

        currentState.GetComponent<Text>().text = "State = " + StateTick;
    }

    void Update()
    {   
        //Debug.Log(" collect brick from GetGO: " + collectBrick._brickCountGm); 

        _currentState = StateTick;

        if (StateTick == 2)
        {
            Debug.Log("-- State Change 1 --");         
        }

        if (_currentState == 4)
        {
            Debug.Log("-- State Change 2 --");
        }

        if (_currentState == 5)
        {
            Debug.Log("-- State Change 3 --");
        }
    }


}
