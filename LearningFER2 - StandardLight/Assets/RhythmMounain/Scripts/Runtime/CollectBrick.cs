using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBrick : MonoBehaviour
{
    public FocusCoin _focus;
    //below is the attempt to figure out how to use the array built in the UI base
    //and wire it here for the state change value 
    //start simple scoring system
    int _fState;
    public static int _focusState;

    private Animator _anim;
    bool _destroyMe = false;
    public bool _goodBrick, _badBrick;
    public bool _green, _red, _blue, _purple;
    int _brickCount; 

    private float timerSpeed = 1;
    private float lastTimestamp;

    //create variables for checks against UI brick color changes, as int
    //one to recieve, one to hold, _getVar; _setVar;
    
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _focus = GetComponent<FocusCoin>();
    }
    void OnTriggerEnter()
    {
        //if UIBrk_color = true, then (goodBrick), else(bad)
        // if (UIBrk_color == _setVar){ this.Object = goodBrick;}
        // else {this.Object = badBrick;}

        //if ( _myMaterials[item] == _fStateInt){ ++ }else{ -- }

        //use a for loop for this, later

        if (_fState == 0)
        {
            Debug.Log(" _fState + " + _fState);
        }
        if (_fState == 1)
        {
            Debug.Log(" _fState + " + _fState);
        }
        if (_fState == 2)
        {
            Debug.Log(" _fState + " + _fState);
        }

        if (_badBrick)
        {
            ScoringSystem.badbrickTick += 2;
            Debug.Log("bad brick");
            _anim.SetBool("Die", true);
            //_destroyMe = true;
        }
        else
        {
            ScoringSystem.goodbrickTick += 1;
            Debug.Log("good brick");
            _anim.SetBool("Die", true);
            //_destroyMe = true;
        } 
        _brickCount += 1;       
        ScoringSystem.brickCount += 1;
        ScoringSystem.brickTick += 1;
        _destroyMe = true;
    }

    void Update()
    {
        _fState = _focusState;

        if (_destroyMe)  //bool to say kill the coin
        {
            if (Time.time - lastTimestamp >= timerSpeed)
            {
                lastTimestamp = Time.time;
                Destroy(gameObject);
            }
        }
    }

}


/* record the coin type
//define publicly how many points for or against in player speed, coin count, time variable

//boom light is idle until collision, then
//play fmod sound, note~hertz for this location
//play animator light_boom
//play animator sphere_boom
//when light_boom is done, then:
//particle effect

   UI_base _UI_base;
    [SerializeField] GameObject brick_UI; //allows the player controller into this GO
    start:
    _UI_base = brick_UI.GetComponent<UI_base>();

        void _focusChanges()
        {
            if (_focusState >= 1)
            { 
            //_state = _uiBase.focusBrickColor;
            Debug.Log(_state);
            }
        }

*/
