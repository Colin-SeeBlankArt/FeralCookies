using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStates : MonoBehaviour
{
    [SerializeField] private Animator BrickAnimator = null;
    [SerializeField] private bool _state1 = true; //broken coin
    [SerializeField] private bool _state2 = false;
    public static int _stateChange = 0; //state 2 will be a complete coin
    int changeMe;

    public static int _bCount; //comes from ScoringSystem
    public static int _cCount; //comes from Timer
    int _bIndex;   

    private void Awake()
    {
        changeMe = _stateChange;
    }

    void Update()
    { 
        if (changeMe >= 0)
        {
            State2();
            _state2 = true;
            changeMe = 0;
        }

    }
    public void State2()
    {
        //BrickAnimator.SetActive(true);    
        BrickAnimator.SetBool("State2", true); //initiates trans to BrickIdle
        Bounce();       
    }
    public void Bounce()
    {
        BrickAnimator.SetBool("Bounce", true); //initiates brick bounce

    }
    public void ChangeState()
    {
        _state1 = false;
    }

}
