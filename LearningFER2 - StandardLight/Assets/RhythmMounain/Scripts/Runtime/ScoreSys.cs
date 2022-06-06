using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSys : MonoBehaviour
{
    public GameObject GBTick;
    private int _playerScore;
 
    public static int goodbrickTick;  //this will be a positive impact on loop count

    private void Start()
    {
        _playerScore = goodbrickTick;
    }
    void Update()
    {       
        GBTick.GetComponent<Text>().text = "Good Brick = " + _playerScore; //counter for the green
    }

}
