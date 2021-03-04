using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public bool isCatched = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "catching")
        {
            isCatched = true;
        }
    }
}
