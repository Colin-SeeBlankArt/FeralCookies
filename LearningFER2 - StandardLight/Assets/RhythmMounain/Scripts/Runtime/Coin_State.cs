using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_State : MonoBehaviour
{

    public Material[] _bMaterial; //potentially change this int at GameManager
    Renderer rend;
    int NewNum;

    private AudioManager _audioManager;

    public int brickState = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = _bMaterial[0];
        RangeRandom(50);
    }
    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }
    //switch compare single to series of constant
    void BrickColor()
    {
        switch (brickState)
        {
            case 3:
                rend.sharedMaterial = _bMaterial[3];
                ScoringSystem._purpTick++;
                _audioManager.Play("BrickPing");
                break;
            case 2:
                rend.sharedMaterial = _bMaterial[2];
                ScoringSystem._blueTick++;
                _audioManager.Play("BrickPing");
                break;
            case 1:
                rend.sharedMaterial = _bMaterial[1];
                ScoringSystem._redTick++;
                //ScoringSystem._negativeBrickTick ++;
                PlayerCtrl._redbrick = 1; //send to playerctl to reduce speed temp
                _audioManager.Play("BunnyPing");
                break;
            default: 
                rend.sharedMaterial = _bMaterial[0];
                ScoringSystem._greenTick++;  //green brick tally
                ScoringSystem._greenBrickTicker++;     //for counter to work in Scoring
                CountDownTimer._timeTrig++;
                _audioManager.Play("BrickPing");
                break;
        }

    }

    public void RangeRandom(int MyNewNum)
    {
        int _ranNum = Random.Range(0, MyNewNum);
        NewNum = _ranNum;
        if (NewNum >= 0 && NewNum <= 34)
        {
            brickState = 0;
        }
        if (NewNum >= 35 && NewNum <= 47)
        {
            brickState = 1;
        }
        if (NewNum == 48)
        {
            brickState = 2;
        }
        if (NewNum == 49)
        {
            brickState = 3;
        }
 
    } 

}
