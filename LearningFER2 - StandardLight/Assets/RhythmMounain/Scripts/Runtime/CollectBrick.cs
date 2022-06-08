using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBrick : MonoBehaviour
{

    //public GameObject _focus;

    //int _fState;
    public static int _focusState;

    private Animator _anim;
    bool _destroyMe = false;
    public bool _goodBrick, _badBrick;
    int _brickCount;
    public static int _penalty= 5;

    private float timerSpeed = 1f;
    private float elapsed;

    //create array to hold states  
    public Material[] material; //potentially change this int at GameManager
    Renderer rend;
    //use these states to change coin colora

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        _anim = GetComponent<Animator>();
        //_focus = GetComponent<FocusCoin>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerTrigger();
        }

        if (collider.CompareTag("Enemy"))
        {
            //DestroyMe();
            Debug.Log("bunny hits a brick");
        }

    }

    void Update()
    {
        //_fState = _focusState;

        if (_destroyMe)  //bool to say kill the coin
        {
            elapsed += Time.deltaTime;
            if (elapsed >= timerSpeed)
            {
                elapsed = 0f;
                Destroy(gameObject);
            }
        }
    }

    public void PlayerTrigger()
    {
        if (_badBrick)
        {
            ScoringSystem.badbrickTick += 2;
            Debug.Log("bad brick");
        }
        else
        {
            ScoringSystem.goodbrickTick += 1;
            Debug.Log("good brick");
        }
        DestroyMe();
        _brickCount += 1;
        ScoringSystem.brickCount += 1;
        ScoringSystem.brickTick += 1;

    }

    public void DestroyMe()
    {
        _destroyMe = true;
        _anim.SetBool("Die", true);
        _anim.SetBool("Light", true);

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
//create variables for checks against UI brick color changes, as int
//one to recieve, one to hold, _getVar; _setVar;

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
