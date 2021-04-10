using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    //first level

public class Level1_GameManager : MonoBehaviour
{
    public static Level1_GameManager instance; //create an instance that is going to be used in another script
    
    // place to store the cubes
    public GameObject innerCube;
    public GameObject outCube;
    
    private void Awake() {
        instance = this;            //make this object the instance
    }

    //when the stage is finished change the tags of the cubes, so that the inner cube is no longer affected and the 
    //outside cubes are the ones affected by all the rotating stuff
    public void FinishStageOne() {
        innerCube.tag = "Untagged"; 
        outCube.tag = "cube";
    }
}
