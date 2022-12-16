using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Forever;

public class LoopMachine : MonoBehaviour
{
    public static LoopMachine instance;
    public GameObject BassA1box;
    //this is the loop counter machine, used to fire off the audio tracks

    [SerializeField]
    private int _loopCountA; //first loop level in a level
    [SerializeField]
    private int _loopCtr;

    public static int _loopPanelToggle = 0;

    //audio controller, needs to trigger song loops at loop counts
    AudioSource audioSourceB;

    private void Awake()
    {
        audioSourceB = GetComponent<AudioSource>();
        instance = this;
        //Invoke("DeactivateMe", audioSourceB.clip.length);
    }
    private void Start()
    {
        BassA1box = GetComponent<GameObject>();
    }
    void Update()
    {
        if (_loopPanelToggle >= 1)
        {
            Debug.Log("Panel Toggle");
            BassA1box.SetActive(true);
            _loopPanelToggle = 0;  
        }
        //PlayingLoops(); 
    }

    public void PlayingLoops()
    {
        audioSourceB.Play();
      
    }

    void PlayingIsTrue()
    {
        //wait the time of the length of the loop to move to the next step
        if (!audioSourceB.isPlaying)
        {
            //wait the time of the length of the loop to move to the next step
            Debug.Log("Audio stopped");
            gameObject.SetActive(false);
        }
    }
        
     
}
