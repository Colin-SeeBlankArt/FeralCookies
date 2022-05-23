using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    public void ChangeScene() //change by name
    {
        SceneManager.LoadScene("Scene_DesignTest_R");

    }

    public void UI_Pop () // use this to test out ideas for "popping" menus telling the player "something" happened
    {
        //create simple 3 sec time, sec 1 fade in, sec 2 read text, sec 3 fade out
        //animate text stating "Pop!" after coin collect
        //animate text stating "Loop Collected", bring in LoopCt from GameManager
    }
}

