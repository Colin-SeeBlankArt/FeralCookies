using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimer : MonoBehaviour
{


    void OnTriggerEnter(Collider collider)// reset the timer when player hits this box.
    {
        if (collider.CompareTag("Player"))
        {
            CountDownTimer._resetTimetk++;
        }
    }
}
