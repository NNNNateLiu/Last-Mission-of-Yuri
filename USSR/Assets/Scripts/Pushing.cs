using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    // the gameobject which hold catching collider

    
    // debug
    public Transform rotatePivot;
    public List<GameObject> catchedCubes;
    public List<GameObject> allCubes;
    public GameObject player;
    public float xRotateAngles;
    public float yRotateAngles;
    public float zRotateAngles;

    // user modify
    public float xRotateModifyer;
    public float yRotateModifyer;
    public float zRotateModifyer;
    public GameObject catching;
    private Collider catchingCollider;
    public Material feedback;
    
    private bool isRotate = false;
    private void Start()
    {
        catchingCollider = catching.GetComponent<Collider>();
        feedback.color = Color.grey;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            catching.SetActive(true);
            feedback.DOColor(Color.green, 1);
            GetCaughtCubes();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            catching.SetActive(false);
            feedback.DOColor(Color.grey, 1);
            ReleaseCaughtCubes();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //catching.SetActive(true);
            //Debug.Log("player enter and catch");
            if (Input.GetKeyDown(KeyCode.T))
            {
                //GetCatchedCubes();
                Debug.Log("start to push");
                PushCaughtCubes();
            }
        }
    }

    // catching collider catch cubes
    public void GetCaughtCubes()
    {
        
        foreach (var cube in allCubes)
        {
            bool isCatched = cube.GetComponent<Cubes>().isCatched;
            if (isCatched)
            {
                catchedCubes.Add(cube);
            }
        }
    }

    public void PushCaughtCubes()
    {
        /*
        xRotateAngles += xRotateModifyer;
        yRotateAngles += yRotateModifyer;
        zRotateAngles += zRotateModifyer;
        */
        
        Debug.Log(xRotateAngles + " " + yRotateAngles + " " + zRotateAngles);
        foreach (var cube in catchedCubes)
        {
            cube.transform.SetParent(rotatePivot);
        }
        rotatePivot.DORotate(new Vector3(xRotateAngles +xRotateModifyer, 
            yRotateAngles + yRotateModifyer,
            zRotateAngles + zRotateModifyer),
            1,RotateMode.Fast);
        
        isRotate = true;
    }

    public void ReleaseCaughtCubes()
    {
        catchedCubes.Clear();
    }
    private void Update()
    {
        Vector3 temp = rotatePivot.eulerAngles;
        xRotateAngles = temp.x;
        yRotateAngles = temp.y;
        zRotateAngles = temp.z;
    }

    public void SetIsRotate()
    {
        isRotate = false;
    }
}

/*

outerwall - Y axis 
    outer green - clockwise
    outer red - clockwise
innerwall - X asis 
    inner red - clockwise
    inner green - anti

*/