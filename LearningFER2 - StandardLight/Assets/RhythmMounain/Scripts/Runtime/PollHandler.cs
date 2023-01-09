using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollHandler : MonoBehaviour
{
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            ScoringSystem._pollLevel = 1;            
        }
        if (val == 1)
        {
            ScoringSystem._pollLevel = 2;
        }
        if (val == 2)
        {
            ScoringSystem._pollLevel = 3;
        }
        if (val == 3)
        {
            ScoringSystem._pollLevel = 4;
        }
        if (val == 4)
        {
            ScoringSystem._pollLevel = 5;
        }
        if (val == 5)
        {
            ScoringSystem._pollLevel = 6;
        }
        if (val == 6)
        {
            ScoringSystem._pollLevel = 7;
        }
    }
    
}
