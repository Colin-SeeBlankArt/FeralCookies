using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    /*
     ================Using this as a Note Pad of ideas for Scriptig=================================

        Brick - Player collides with Brick Tag, Bricks with Tag are destroyed. 
        Focus Brick - this Brick will define which type of Brick is active for positive gains in the players movement stats, Brick stats, and Impending Doom's stats.
        Loop - earn the proper numbers of Focus Bricks, complete the loop to a specified level:

            0-25% - not much changes, Loop is a "Start Mode" meaning the player must collect more Focus Notes.
                    Bricks are diificult to dicern which type they are, the Focus Brick looks like the Non-Focus Bricks
                    The Focus Bricks become easier to define as more notes are there. Easy Measures can have simple note structures
                    Add dificulty by adding different layers to the loops brick (note variation, tempo variation, pitch variation)

            25-50% - Secondary Loop Bricks begin to show, allowing the player to see which Brick is correct.


    ===========================NoteBrickScripts========================================

    Do I need a NoteBrick Behaviour script?
    Public variables to consider:
    Color
    Start Current State (default 0)
    Good Brick (bool)
        If Yes (did FocusBrick make me true?)
            brickcount +1;
            playerspeed +1;
        If Bonus (bool, random loop, 1 in 16 (??) )
            brickcount +2;
            playerBoost for 10 frames; can hold? (inv)
            Can we straighten the track out in real time?

    State Values:
        State 1 FireFly Particles
        State 2 Large but Fewer Particles
        State 3 solid, small objects (voronoi brick from max)
        State 4 solid, bouncing around track
        State 5 on track, collider is on
        State 6 dead, destroyed, play partilce, quick sprite anim for score awareness
    

    make a script for StateChange, general purpose

    public class Statechange : Monobehaviour
    {
        public GameMngr _gmManager;

    }
 
    if (StateTicker == 10)
        {
            _anim.SetBool("State_Trig_01", true);
            Debug.Log("-- BrickChange 2--");
            //if the value of the loop meter moves above ( a value not yet decided upon), then move to state 2         
        }
     
     
     */


}
