using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FocusCoin : MonoBehaviour
{
    //changing color based on array
    public Material[] material;
    Renderer rend; 

    public int focusBrickColor;

    //using these for random timer to change FocusBrick color
    private float timerSpeed = 10f;
    private float elapsed;
    public int randomValue;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }
    private void Update() //currently just a timer to initiate color change
    {           
        elapsed += Time.deltaTime;
        if(elapsed >= timerSpeed)
        {
            elapsed = 0f;                    
            ChangeFocusBrick(3); //sets max number in randomizer
        }

    }

    public void ChangeFocusBrick(int maxNum)
    {
        // this can be put into an array which will name each item, and return the values I need. 
        int randomNum = Random.Range(0, maxNum);
        focusBrickColor = randomNum;
        if (focusBrickColor == 0)
        {
            Debug.Log("Focus" + focusBrickColor);
            rend.sharedMaterial = material[focusBrickColor];
            CollectBrick._focusState += 0;
        }
        if (focusBrickColor == 1)
        {
            Debug.Log("Focus" + focusBrickColor);
            rend.sharedMaterial = material[focusBrickColor];
            CollectBrick._focusState += 1;
        }
        if (focusBrickColor == 2)
        {
            Debug.Log("Focus" + focusBrickColor);
            rend.sharedMaterial = material[focusBrickColor];
            CollectBrick._focusState += 2;
        }
    }

}

/*
 
public void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    update if(thing){PickRandomNum(4);} //random in range of 4, as it is MaxNumber
 
   public void PickRandomNum(int maxInt)
    {
        int randomNum = Random.Range(1, maxInt);
        randomValue = randomNum;
        Debug.Log("RanNum: " + randomValue);
    }

    */
