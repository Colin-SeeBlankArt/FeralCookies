using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMachine : MonoBehaviour
{
    private float varTime = 0;
    //loop counter
    //loop
    private void Update()
    {
       
        float elapsed = Time.time - varTime;
        float duration = 2.0f;
        float scalar = elapsed / duration;
        Debug.Log($"current scalar value {scalar}");
        if (Input.GetKey(KeyCode.R))
        {
            ResetTimer();
        }

    }

    private void ResetTimer()
    {
        varTime = Time.time;

    }

}
