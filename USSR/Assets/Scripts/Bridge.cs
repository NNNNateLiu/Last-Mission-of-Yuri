﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    // Used on the bridges objects for Level2

public class Bridge : MonoBehaviour
{   // Variable to store the bridge objects
    public GameObject bridge1;
    public GameObject bridge2;
    
    
    public GameObject pushing;      //this is not being used, but I assume if for pushing the walls
    public string connectionTag;

    public bool isConnected;        //this is also not used, for this one I think is about what it mean for all the bridges to be in place 

    // When activating a trigger
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if( other.tag == connectionTag) {           //when the yellow lines line up
            LiftBridge();                           //run the LiftBridge function
        }

        //pushing.GetComponent<Pushing>().canPush &&    <- this is commented out can we take it out?
    }

    // When exiting a trigger
    private void OnTriggerExit(Collider other) {
        if (other.tag == connectionTag) {           //when the yellow lines are not line up
            LowerBridge();                          //run the LowerBridge function
        }
    }

    // A function to lift the bridge, it determines the direction of the rotation
    public void LiftBridge() {
        bridge1.transform.DOLocalRotate(new Vector3(0, 0, 180), 1,RotateMode.Fast);
        bridge2.transform.DOLocalRotate(new Vector3(0, 0, 0), 1, RotateMode.Fast);
    }

    // A function to lower the bridge, it determines the direction of the rotation
    public void LowerBridge() {
        bridge1.transform.DOLocalRotate(new Vector3(0, 0, 270), 1, RotateMode.Fast);
        bridge2.transform.DOLocalRotate(new Vector3(0, 0, -90), 1, RotateMode.Fast);
    }
}