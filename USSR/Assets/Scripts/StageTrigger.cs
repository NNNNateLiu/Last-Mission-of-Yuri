using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// I dont think we are using this
public class StageTrigger : MonoBehaviour
{
    public Material feedback;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")                          //if the other object has the Player tag
        { 
            feedback.DOColor(Color.red, 1);        //change the color to the default color grey                       //run the ReleaseCaughtCubes function
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player");
            if(Input.GetKeyDown(KeyCode.T))
            {
                StageController.instance.OnLevel1Finish();
            }
        }
    }
}
