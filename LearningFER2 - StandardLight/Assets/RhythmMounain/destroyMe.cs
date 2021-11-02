using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class destroyMe : MonoBehaviour
    {

    void OnTriggerEnter(Collider other)
    {
     Destroy(other.gameObject);
        Debug.Log("Killed me!");
    }
}






     