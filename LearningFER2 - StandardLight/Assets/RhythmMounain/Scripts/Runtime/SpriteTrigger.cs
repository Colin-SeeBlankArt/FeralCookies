using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTrigger : MonoBehaviour
{
    private float elapsed;
    private float timerSpeed = 0.5f;
    void Update()
    {
            elapsed += Time.deltaTime;
            if (elapsed >= timerSpeed)
            {
                elapsed = 0f;
                Destroy(this);
            }
    }

}
