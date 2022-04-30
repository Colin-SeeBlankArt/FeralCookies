using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBrick : MonoBehaviour
{
    private Animator _anim;
    bool _destroyMe = false;
    //public float interval;
    public bool _goodBrick, _badBrick;
    int _brickCount;


    private float timerSpeed = 1;
    private float lastTimestamp;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void OnTriggerEnter()
    {

        if (_badBrick)
        {
            ScoringSystem.badbrickTick += 2;
            Debug.Log("bad brick");
            _anim.SetBool("Die", true);
            _destroyMe = true;
        }
        else
        {
            ScoringSystem.goodbrickTick += 1;
            Debug.Log("good brick");
            _anim.SetBool("Die", true);
            _destroyMe = true;
        } 

        _brickCount += 1;
        
        ScoringSystem.brickCount += 1;
        ScoringSystem.brickTick += 1;
        _destroyMe = true;
    }


    void Update()
    {
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


*/
