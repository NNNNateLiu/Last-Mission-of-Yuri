using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level1RedGreenDoor : MonoBehaviour
{
    public static Level1RedGreenDoor instance;
    public GameObject greenDoor;
    public GameObject doorRotatePivot;
    public GameObject doorBlocker;
    public bool canOpen;
    public bool stopToOpen;
    public AudioSource DoorOpen;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "GreenDoor")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "GreenDoor")
        {
            canOpen = false;
        }
    }

    public void RedGreenDoorOpen()
    {
        greenDoor.transform.SetParent(doorRotatePivot.transform);
        doorBlocker.SetActive(false);
        doorRotatePivot.transform.DOLocalRotate(new Vector3(180, 0, 0), 8, RotateMode.Fast);
        DoorOpen.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<PPAdjust>().SwitchPostProcessing();
    }

    private void Update()
    {
        if(stopToOpen)
        {
            RedGreenDoorOpen();
            stopToOpen = false;
        }
    }

}
