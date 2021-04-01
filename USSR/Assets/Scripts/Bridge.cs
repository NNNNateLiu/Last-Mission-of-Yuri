using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bridge : MonoBehaviour
{
    public GameObject bridge1;
    public GameObject bridge2;
    public GameObject pushing;
    public string connectionTag;

    public bool isConnected;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if( other.tag == connectionTag)
        {
            LiftBridge();
        }

        //pushing.GetComponent<Pushing>().canPush &&
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == connectionTag)
        {
            LowerBridge();
        }
    }

    public void LiftBridge()
    {
        bridge1.transform.DOLocalRotate(new Vector3(0, 0, 180), 1,RotateMode.Fast);
        bridge2.transform.DOLocalRotate(new Vector3(0, 0, 0), 1, RotateMode.Fast);
    }

    public void LowerBridge()
    {
        bridge1.transform.DOLocalRotate(new Vector3(0, 0, 270), 1, RotateMode.Fast);
        bridge2.transform.DOLocalRotate(new Vector3(0, 0, -90), 1, RotateMode.Fast);
    }

    private void Start()
    {
        
    }

}
