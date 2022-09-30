using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBrick : MonoBehaviour
{
    [SerializeField] private GameObject _boomSprite;
    [SerializeField] private GameObject _Particlecube;

    public static int _focusState;
    private Animator _anim;
    bool _destroyMe = false;
    bool _greenbrick = false;
    bool _badBrick = false;
    bool _purpStacking = false;

    private float timerSpeed = 0.2f;
    private float elapsed;

    public Material[] _bMaterial; //potentially change this int at GameManager
    Renderer rend;

    public int brickState = 1;

    int NewNum;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = _bMaterial[0];
        _anim = GetComponent<Animator>();
        RangeRandom(50);
    }
   
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerTrigger();         
        }

        if (collider.CompareTag("Enemy"))
        {
            Debug.Log("bunny hits a brick");
            BrickChange();
            rend.sharedMaterial = _bMaterial[1];
            _badBrick = true;
        }

        
    }

    void Update()
    {
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
            ScoringSystem.badbrickTick++;
            CountDownTimer._bunnyTrig++;
        }
        if (_purpStacking)
        {
            ScoringSystem._purpStack++;
            Debug.Log("Purple Stacks");
        }

        if (_greenbrick)
        {
            ScoringSystem.goodbrickTick++;
            ScoringSystem._loopTicker++;
            CountDownTimer._timeTrig++;
        }
        DestroyMe(); 
    }

    public void DestroyMe()
    {
        _destroyMe = true;
        Instantiate(_boomSprite, transform.position, transform.rotation);
        Instantiate(_Particlecube, transform.position, transform.rotation);
    }//obvious

    public void RangeRandom(int MyNewNum)
    {
        int _ranNum = Random.Range(0, MyNewNum);
        NewNum = _ranNum;
        if (NewNum >= 0 && NewNum <= 34)
        {
            rend.sharedMaterial = _bMaterial[0];
            _greenbrick = true;
            //Debug.Log("Color Range 1");
        }
        if (NewNum >= 35 && NewNum <= 46)
        {
            rend.sharedMaterial = _bMaterial[1];
            //Debug.Log("Color Range 2");
            _badBrick = true;
        }
        if (NewNum == 47)
        {
            rend.sharedMaterial = _bMaterial[2];
            //Debug.Log("Color Range 3");
            _purpStacking = true;
        }
        if (NewNum == 48)
        {
            rend.sharedMaterial = _bMaterial[3];

            //Debug.Log("Color Range 4");
        }
        if (NewNum == 49)
        {
            //Debug.Log("Color Range 5");
        }
    } //changes colors, percentaged based

    public void BrickChange()
    {
        if (brickState == 1)
        {

        }
        else if (brickState == 2)
        {
            
        }
        else if (brickState == 3)
        {
            //blue
        }
        else if (brickState == 3)
        {
            //purple
        }
    }

}

/*



     public void colorChange(int maxNum) 
    {
        int randomNum = Random.Range(0, maxNum);
        _colorRandomize = randomNum;
        if (_colorRandomize == 0) 
        {
            rend.sharedMaterial = _bMaterial[_colorRandomize];          
        }
        if (_colorRandomize == 1) 
        {
            rend.sharedMaterial = _bMaterial[_colorRandomize];
        }
        if (_colorRandomize == 2)
        {
            rend.sharedMaterial = _bMaterial[_colorRandomize];
        }
        if (_colorRandomize == 3) 
        {
            rend.sharedMaterial = _bMaterial[_colorRandomize];
        }
    } 
     record the coin type

        ScoringSystem.TICK = 2;

//define publicly how many points for or against in player speed, coin count, time variable


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
