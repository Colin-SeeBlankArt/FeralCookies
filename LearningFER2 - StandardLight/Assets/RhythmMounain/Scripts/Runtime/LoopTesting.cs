using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTesting : MonoBehaviour
{
    int numEnemies = 10;

    int NBxLoc = 6;
    int NByLoc = 8;

    void Start()
    {
        for(int i = 0; i <= numEnemies; i++)
        {
            Debug.Log("Creating EneyNumber: " +i);  
        }

        for(int j = 0; j <= NBxLoc; j++)
        {
            Debug.Log("Creating NoteBrick X Frequency: " + j);
        }

    }

}
