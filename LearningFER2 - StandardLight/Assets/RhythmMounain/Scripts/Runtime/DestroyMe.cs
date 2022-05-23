using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyMe : MonoBehaviour
{
    public float interval;
    public static int trigVar;


    void Update()
    {
 
        if (trigVar == 2)
        {
            Debug.Log(trigVar);
            Destroy(gameObject, interval);
        }

    }
}
