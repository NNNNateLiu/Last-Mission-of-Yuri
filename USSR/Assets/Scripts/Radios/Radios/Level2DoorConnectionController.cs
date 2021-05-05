using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level2DoorConnectionController : Radio
{
    public AudioSource OpenAudio;
    public GameObject connectionDoor;
    public GameObject doorCollider;
    public AudioSource correctCombo;
    public AudioSource invalidCombo;


    public override void AfterPressEnter()
    {
         if(currentCombo == rightCombo){
        OpenAudio.Play();
        ChangeRadioCameraState();
        doorCollider.SetActive(false);
        connectionDoor.transform.DORotate(new Vector3(120f, 0f, 0f), 6f, RotateMode.Fast);}
        else{
            invalidCombo.Play();
        }
    }
}
