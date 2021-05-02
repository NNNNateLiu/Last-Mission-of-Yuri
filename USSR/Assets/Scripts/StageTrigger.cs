using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// temp code for testing purpose... allows teleport
public class StageTrigger : MonoBehaviour
{
    public Material feedback;
    public GameObject connectionDoor;
    public GameObject doorCollider;

    public float rotateTime;
    public float rotateAngleX;
    public float rotateAngleY;
    public float rotateAngleZ;
    public AudioSource OpenAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")                          //if the other object has the Player tag
        { 
            feedback.DOColor(Color.red, 1);        //change the color to the default color grey                       //run the ReleaseCaughtCubes function
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")                          //if the other object has the Player tag
        {
            feedback.DOColor(Color.green, 1);        //change the color to the default color grey                       //run the ReleaseCaughtCubes function
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player");
            if(Input.GetKeyDown(KeyCode.T))
            {   OpenAudio.Play();
                doorCollider.SetActive(false);
                connectionDoor.transform.DORotate(new Vector3(rotateAngleX, rotateAngleY, rotateAngleZ), rotateTime, RotateMode.Fast);
            }
        }
    }
}
