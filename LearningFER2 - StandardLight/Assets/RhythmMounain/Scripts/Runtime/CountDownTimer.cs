using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDownTimer : MonoBehaviour
{
    public static CountDownTimer instance;
    public static bool timerIsRunning = false;
    public Text timeText;

    public Slider timerSlider;

    public static int _timeTrig = 0; // Trigger for CollectBrick
    public static int _bunnyTrig = 0; // If pc25 hits Bunny trigger

    public int _bonusTime; //Value for simple time bonus 
    public int timeLeft;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Starts the timer automatically
        //StartTimer();
        timerSlider.maxValue = timeLeft;  
        timerSlider.value = timeLeft;      
        StartCoroutine("LoseTime");
    }
    void Update()
    {
        DisplayTime(timeLeft);

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
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerSlider.value = timeToDisplay;
    }
    public void StartTimer()
    {
        if (timerIsRunning)
        {
            timerIsRunning = true;
            Time.timeScale = 1;
        }
    }
    public void BonusTime()
    {
        timeLeft += _bonusTime;
    }
    public void BunnyTime()
    {
        timeLeft -= _bonusTime;
    }
    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            timeLeft--;
        }

    }
}

/*NOTES
 * 
 * 
 * 
 * */
