using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject CountTheBricks;
    public static int theScore;

    //want to use these to create variables for the testing side of the app
    int currentBrickcount;
    int brickGoal;

    void Update()
    {
        CountTheBricks.GetComponent<Text>().text = "Bricks " + theScore;           
    }

}
