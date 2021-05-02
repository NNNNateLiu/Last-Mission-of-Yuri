using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level2DoorConnectionController : Radio
{
    public AudioSource OpenAudio;
    public GameObject connectionDoor;
    public GameObject doorCollider;

    public override void AfterPressEnter()
    {
        OpenAudio.Play();
        ChangeRadioCameraState();
        doorCollider.SetActive(false);
        connectionDoor.transform.DORotate(new Vector3(120f, 0f, 0f), 6f, RotateMode.Fast);
    }
}
