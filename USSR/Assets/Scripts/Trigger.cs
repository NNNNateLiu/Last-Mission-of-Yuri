using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    /* I have a few questions here:
     A. Wouldn't it be better for this to be like a scene loader? if we are having each level
     B. Can we change the name to something like EndingStage?
     C. Actually, does this need to be its own script? Can it not be part of the Level1_GameManager at the very least?*/
    
    // End the level when the players activates the trigger
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {                            //if the player is the one triggering
            Level1_GameManager.instance.FinishStageOne();       //run the FinishStageOne function
        }
    }
}
