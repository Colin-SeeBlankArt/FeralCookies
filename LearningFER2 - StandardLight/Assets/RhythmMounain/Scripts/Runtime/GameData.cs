using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int totalBrickCount;
    public int badbrick;
    public int goodbrick;
    public int pcscore;

    public GameData (ScoringSystem scoreData) //constructor
    {
        totalBrickCount = scoreData.totBrickCt;
        badbrick = scoreData.badBrickTot;
        goodbrick = scoreData.goodBrickTot;
        pcscore = scoreData.pcScore;
    }


    
}
/*NOTES
 * 
 * 
 */