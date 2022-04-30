using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicTimer : MonoBehaviour
{
    [SerializeField]
    private float timerSpeed = 2;
    private float lastTimestamp;

    // Update is called once per frame
    private void Update()
    {   if (Time.time - lastTimestamp >= timerSpeed)
        {
            lastTimestamp = Time.time;
            // GetComponent<componentName>().method;
            //GetComponent<Flasher>().Flash();
        }
    }
}
