using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

//used on both scene
public class Pushing : MonoBehaviour
{
    //Hotfix after Dylan destroy our game: add a cold down for each push
    private float pushWaitTime = 1;
    private float pushTimer = 0;
    public bool canPush;

    // the gameobject which hold catching collider
    public Transform rotatePivot;
    private float xRotateAngles;
    private float yRotateAngles;
    private float zRotateAngles;

    //Create list to group up the active cubes
    public List<GameObject> catchedCubes;
    public List<GameObject> allCubes;

    // variables to determine who the object is going to be modified
    public float xRotateModifyer;
    public float yRotateModifyer;
    public float zRotateModifyer;
    public GameObject catching;
    private Collider catchingCollider;
    public Material feedback;
    
    private bool isRotate = false;                      //variable to determine is the object was rotated
    public AudioSource RotateSound;

    private void Start()
    {
        catchingCollider = catching.GetComponent<Collider>();       //get the collider component
        feedback.color = Color.black;                                //set the color to grey as default color
        feedback.SetColor("_EmissionColor",new Vector4(0,0.22f,0.18f,0));
    }

    // catching collider catch cubes

    public void GetCaughtCubes()
    {
        foreach (var cube in allCubes)             //run foreach cube in the allCubes list
        {
            bool isCatched = cube.GetComponent<Cubes>().isCatched; //get the boolean value from the cube script
            if (isCatched) {                                  //if boolean true
                catchedCubes.Add(cube);                      //add the cube to the list of catchedCubes
            }
        }
    }

    public void PushCaughtCubes()
    {
        canPush = false;
        Debug.Log(xRotateAngles + " " + yRotateAngles + " " + zRotateAngles);
        foreach (var cube in catchedCubes) {          //run for each cube in the catchedCubes list
            cube.transform.SetParent(rotatePivot);             //set another transform as their parent 
        }
        RotateSound.Play();
        //rotate the object
        rotatePivot.DORotate(new Vector3(xRotateAngles +xRotateModifyer, 
            yRotateAngles + yRotateModifyer,
            zRotateAngles + zRotateModifyer),
            1,RotateMode.Fast);
        
        isRotate = true;    //set the object as rotated
    }

    public void ReleaseCaughtCubes() 
    {
        catchedCubes.Clear();               //empty the catchedCubes list
    }

    public void Level1RedGreenDoorOpenCheck()
    {
        if(Level1RedGreenDoor.instance.canOpen)
        {
         Level1RedGreenDoor.instance.stopToOpen = true;
        }
    }

    public void WhenPlayerEnter()
    {
        catching.SetActive(true);                       //activate catching
        feedback.DOColor(Color.green, 1);       //change the color to green
        feedback.SetColor("_EmissionColor", new Vector4(0, 0.75f, 0.4f, -0.2f));
        GetCaughtCubes();
    }

    public void WhenPlayerExit()
    {
        catching.SetActive(false);                      //deactivate catching
        feedback.DOColor(Color.black, 1);        //change the color to the default color grey
        feedback.SetColor("_EmissionColor", new Vector4(0, 0.22f, 0.18f, 0));
        ReleaseCaughtCubes();
    }

    private void Update()
    {   
        Vector3 temp = rotatePivot.eulerAngles;
        xRotateAngles = temp.x;
        yRotateAngles = temp.y;
        zRotateAngles = temp.z;

        if (!canPush)
        {
            pushTimer += Time.deltaTime;
            if (pushTimer >= pushWaitTime)
            {
                canPush = true;
                Level1RedGreenDoorOpenCheck();
                pushTimer = 0;
            }
        }
    }
}