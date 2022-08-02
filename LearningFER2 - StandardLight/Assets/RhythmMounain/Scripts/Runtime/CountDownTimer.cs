using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDownTimer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;

    public Slider timerSlider;

    public static float _timeBonus = 0;
    public float _tbonus;
    float _curTime;
    float _newTime;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timerSlider.maxValue = timeRemaining;
        timerSlider.value = timeRemaining;
        _tbonus = _timeBonus;
        _curTime = Time.deltaTime;
    }
    void Update()
    {


        if (timerIsRunning)
        {
            BonusTime();

            if (timeRemaining > 0)
            {

                timeRemaining -= _curTime;
                BonusTime();
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameManager._endTime = true;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerSlider.value = timeToDisplay;        
    }

    void BonusTime()
    {
        if (_tbonus > 0)
        {
            Debug.Log("Bonus Time = " + _timeBonus);
            _tbonus = 0;
            _curTime += 0.5f;
        }

    }
}
