using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;


public class PingTest : MonoBehaviour
{
    
    [SerializeField] private int[] numbers;
    [SerializeField] private List<string> names = new List<string>();

    LaneRunner myRunner;
    float speed = 0f;
    float startSpeed = 0f;
 
    public int varA; //script to script, passer

    public static int PingMe = 0;

    public void Awake()
    {
        myRunner = GetComponent<LaneRunner>();
        startSpeed = speed = myRunner.followSpeed;
    }

    private void Update ()
    {
        if (PingMe > 0)
        {
            Debug.Log("!! Ping Me !!");
        }


        if (Input.GetMouseButtonDown(0))
        {
            numbers.Shuffle(6);
            names.Shuffle(6);


        }
    }


}

// shuffle array, and try a list out. 
//conceptually, I want to toggle the states for the bricks
/*
 * from unity tutorial on get components
 * 
 * public class AnotherScript : MonoBehaviour{ public int playerScore = 9001;}
 * 
 * public class YetAnotherScript : MonoBehaviour{ public in numberOfPlayerDeaths = 3;}
 * 
 * public class UsingOtherComponents: Mono{
 * public GameObject otherGameObject;
 * private AnotherScript anotherscript;
 * private YetAnotherScript yetanotherscript;
 * void awake
 * {
 *  anotherscript = GetComponent<AnotherScript>();
 *  yetAnotherScript = GetComponent<YetAnotherScript>();
 *  }
 * 
 * 
 */
