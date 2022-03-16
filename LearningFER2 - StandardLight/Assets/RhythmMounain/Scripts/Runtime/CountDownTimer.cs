using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 100f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
      /*  timmer counting down, does this need to be in a different script??  
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
      */
        //how to pause game with this. 
        //add mins/sec in display

         currentTime += 1 * Time.deltaTime;
         countdownText.text = currentTime.ToString("0");
          
         if (currentTime >= 100)
         {
               currentTime = 0;
         }
         
         
    }


}
