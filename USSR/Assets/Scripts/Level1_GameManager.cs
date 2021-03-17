using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_GameManager : MonoBehaviour
{
    public static Level1_GameManager instance;
    public GameObject innerCube;
    public GameObject outCube;

    //public GameObject gravityPlane;
    //public GameObject staticObject;

    private void Awake()
    {
        instance = this;
    }

    public void FinishStageOne()
    {
        innerCube.tag = "Untagged";
        outCube.tag = "cube";
    }
}
