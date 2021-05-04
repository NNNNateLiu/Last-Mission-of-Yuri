using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_5Teleport : MonoBehaviour
{
    public GameObject player;
    public Transform transPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.position = transPoint.position;
        }
    }
}
