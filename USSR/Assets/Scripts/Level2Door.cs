using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    // Used on the bridges objects for Level2

public class Level2Door : MonoBehaviour
{   // Variable to store the bridge objects
    public GameObject door1;

    public Animator doorAnim;
    public bool isOpen;
    
    public string connectionTag;
    
    // When activating a trigger
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if( other.tag == connectionTag) {           //when the yellow lines line up
            OpenDoor();                           //run the LiftBridge function
        }
    }

    // When exiting a trigger
    private void OnTriggerExit(Collider other) {
        if (other.tag == connectionTag) {           //when the yellow lines are not line up
            CloseDoor();                          //run the LowerBridge function
        }
    }

    // A function to lift the bridge, it determines the direction of the rotation
    public void OpenDoor() {
        //door1.transform.DOLocalRotate(new Vector3(-180f, 0f, 0f), 1,RotateMode.Fast);
        //door2.transform.DOLocalRotate(new Vector3(-180f, 0f, 0f), 1, RotateMode.Fast);
        doorAnim.SetBool("isOpen", true);
    }

    // A function to lower the bridge, it determines the direction of the rotation
    public void CloseDoor() {
        //door1.transform.rotation = Quaternion.Euler(new Vector3(180, 0, 0));
        //door1.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 1, RotateMode.Fast);
        //door2.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 1, RotateMode.Fast);
        doorAnim.SetBool("isOpen", false); ;
    }
}
