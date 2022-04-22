using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_base : MonoBehaviour
{
    public void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public Slider slider; //rename to loop meeter

    public void SetMaxloopMeter(int loopMeter)
    {
        slider.maxValue = loopMeter;
        slider.minValue = loopMeter;
    }

    public void SetLoopCounter(int loopMeter)
    {
        slider.value = loopMeter;

    }
}
