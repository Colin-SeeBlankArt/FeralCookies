using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollHandler : MonoBehaviour
{
    public void HandleInputDataA(int val)
    {
        if (val == 0)
        {
            ScoringSystem._pollLevel_1 = 1;            
        }
        if (val == 1)
        {
            ScoringSystem._pollLevel_1 = 2;
        }
        if (val == 2)
        {
            ScoringSystem._pollLevel_1 = 3;
        }
        if (val == 3)
        {
            ScoringSystem._pollLevel_1 = 4;
        }
        if (val == 4)
        {
            ScoringSystem._pollLevel_1 = 5;
        }
        if (val == 5)
        {
            ScoringSystem._pollLevel_1 = 6;
        }
        if (val == 6)
        {
            ScoringSystem._pollLevel_1 = 7;
        }
    }



}
