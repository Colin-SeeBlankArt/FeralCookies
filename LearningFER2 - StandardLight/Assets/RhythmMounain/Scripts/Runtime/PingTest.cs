using System.Collections.Generic;
using UnityEngine;


public class PingTest : MonoBehaviour
{
    [SerializeField] private int[] numbers;
    [SerializeField] private List<string> names = new List<string>();

    public int varA; //script to script, passer

    public static int PingMe = 0;

    private void Update ()
    {
        if (PingMe > 0)
        {
            Debug.Log("!! Ping Me !!");
        }


        if (Input.GetMouseButtonUp(0))
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
