using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)// reset the timer when player hits this box.
    {
        if (collider.CompareTag("Player"))
        {
            CountDownTimer._resetTimetk++;
        }
    }
}
