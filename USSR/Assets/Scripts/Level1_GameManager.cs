using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    //by the name i'm guessing this is being use on the first level, not sure why

public class Level1_GameManager : MonoBehaviour
{
    public static Level1_GameManager instance;
    
    // place to store cubes
    public GameObject innerCube;
    public GameObject outCube;

    //public GameObject gravityPlane;   <-not using it can we erase?
    //public GameObject staticObject;   <-not using it can we erase?

    private void Awake()
    {
        instance = this;            //my every script question
    }

    //when the stage is finished change the tags of the cubes
    public void FinishStageOne() {
        innerCube.tag = "Untagged"; 
        outCube.tag = "cube";
    }
}
