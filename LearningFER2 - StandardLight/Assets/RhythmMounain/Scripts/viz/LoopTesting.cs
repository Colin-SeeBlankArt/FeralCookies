using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTesting : MonoBehaviour
{
    int numEnemies = 10;

    int NBxLoc = 6;
    int NByLoc = 8;
    int _fState;

    int _coordI;
    int _coordJ;    
    int _coordK;

    public GameObject myPrefab;

    void Start()
    {
        for(int i = 0; i <= numEnemies; i++)
        {
            _coordI = i;
        }
        for (int k = 0; k <= NByLoc; k++)
        {
            _coordK = k;
        }

        for (int j = 0; j <= NBxLoc; j++)
        {
            _fState += j;
            _coordJ = j;
            Debug.Log(" _fState = " + _fState); 
        }

    }

}


/*To intsantiate the NBs on the Levels, I will need:
 * _NBct - how many per level - essentially this + _xpos = Frenquency
 * _xPos - tracks x position on levelSegs - this places items
 *  _xSegLength - Max limit of x direction, based on length of track (static)
 *  
 * _yPos - tracks y position on levelSegs - this is locked to lane count (6)
 * _yPos Conditions will be needed
 *
 * _ySegLength - Max limit of y direction, based on length of track (static)
 * both of these are limited by the length of segment
 * 
 * _NB[GameObject<ByTag>("nb")
 * the array holds the GO's by tag
 * 
 */
