using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Trigger : MonoBehaviour
{
    public GameObject player;
    public GameObject gravityField;
    public GameObject Level4StageTriggerRotatePivot;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.parent = Level4StageTriggerRotatePivot.transform;
            gravityField.transform.parent = Level4StageTriggerRotatePivot.transform;
        }
    }
}
