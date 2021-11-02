using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;

public class LRunner : MonoBehaviour
{
    public float jumpForce = 10f;
    LaneRunner runner;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        runner = GetComponent<LaneRunner>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.LeftArrow)) runner.lane--;
       // Debug.Log("left arrow button pressed");
    
        if (Input.GetKeyDown(KeyCode.RightArrow)) runner.lane++;
       // Debug.Log("right arrow button pressed");

        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       // Debug.Log("spacebar button pressed");
    }
}
