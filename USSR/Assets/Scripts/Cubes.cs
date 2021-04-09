using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
    //use on both level
public class Cubes : MonoBehaviour
{
    //variable that determine if something is inside collider
    public bool isCatched = false;
    
    // Called once per physics update for every collider touching the trigger
    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "catching") {       //if the other collider has the catching tag
            isCatched = true;               //set isCatched as true
        }
    }
}
