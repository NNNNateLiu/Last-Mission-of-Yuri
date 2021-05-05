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

    public void WhenPlayerEnter()
    {
        feedback.DOColor(Color.red, 1);
    }

    public void WhenPlayerExit()
    {
        feedback.DOColor(Color.green, 1);
    }

    public virtual void OnInteract()
    {
        OpenAudio.Play();
        doorCollider.SetActive(false);
        connectionDoor.transform.DORotate(new Vector3(rotateAngleX, rotateAngleY, rotateAngleZ), rotateTime, RotateMode.Fast);
    }
}
