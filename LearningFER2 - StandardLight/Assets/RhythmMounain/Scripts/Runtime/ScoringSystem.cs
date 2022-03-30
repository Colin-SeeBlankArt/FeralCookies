using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject CountTheBricks;
    public GameObject TenBrickCounter;
    public GameObject BrickTen;
    public static int theScore;
    public static int tenBricks = 0;
    public static int currentBrickcount = 0;
    
    void Update()
    {
        CountTheBricks.GetComponent<Text>().text = "Totals " + theScore;

        TenBrickCounter.GetComponent<Text>().text = "Bars " + tenBricks;

        BrickTen.GetComponent<Text>().text = "Ten Brick Count " + currentBrickcount;


        if (currentBrickcount >= 10)
        {
            currentBrickcount = 0;
            tenBricks +=1;
        }
    }



}
