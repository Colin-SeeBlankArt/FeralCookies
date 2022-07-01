using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    [SerializeField] private GameObject closeTrigObj;
    [SerializeField] private GameObject openTrigObj;

    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";

    private void Awake()
    {
        closeTrigObj.SetActive(false);
        openTrigObj.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)

            {
                myDoor.Play(doorOpen, 0, 0.0f);
                gameObject.SetActive(false);
                closeTrigObj.SetActive(true);
            }

            else if (closeTrigger)              
            {
                myDoor.Play(doorClose, 0, 0.0f);
                openTrigObj.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}



