using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour
{
    public static CountDownTimer instance;
    public static bool timerIsRunning = false;
    //public Text _gameText;              // Set up Game Player timer (down)
    public Text _totalTime;             // Over All Time for Game (up)
    public Slider timerSlider;

    public int _timeLeft;               // Public value for simple time bonus 
    int timeLeft;                       // working int for Timer Enum

    public static int _resetTimetk=0;   // Trigger for ResetTimer Object
    public static int _timeTrig = 0;    // Trigger for CollectBrick
    public static int _bunnyTrig = 0;   // If PC hits Bunny trigger
    public int _bonusTime;              // If PC hits good coin, add time

    int _timerTime;                     // Total game timer

    private void Awake()
    {
        instance = this;
        timeLeft = _timeLeft;
    }
    private void Start()
    {
        timerSlider.maxValue = timeLeft;
        timerSlider.value = timeLeft;
        StartCoroutine("LoseTime");
    }
    void Update()
    {
        
        if (_timeTrig == 1)
        {
            BonusTime();
            _timeTrig = 0;
        }
        if (_bunnyTrig == 1)
        {
            BunnyTime();
            _bunnyTrig = 0;
        }

        OverallTime(_timerTime);
        
        if(_resetTimetk == 1)
        {
            timeLeft = _timeLeft;
            _resetTimetk = 0;
            print("reset timer");
        }
    }
    
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;                 // count Down
            _timerTime++;               // count Up
        }
    }


    void OverallTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);       
        _totalTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void BonusTime()
    {
        timeLeft += _bonusTime;
    }
    public void BunnyTime()
    {
        timeLeft -= _bonusTime;
    }
}
/*
/
    GamePlayTime(timeLeft); 
    void GamePlayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _gameText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerSlider.value = timeToDisplay;
    }

 
 */