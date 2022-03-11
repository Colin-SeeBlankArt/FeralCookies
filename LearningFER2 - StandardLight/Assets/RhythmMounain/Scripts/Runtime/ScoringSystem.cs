using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject CountTheBricks;
    public static int theScore;

    void Update()
    {
        CountTheBricks.GetComponent<Text>().text = "Bricks " + theScore;
    }

}
