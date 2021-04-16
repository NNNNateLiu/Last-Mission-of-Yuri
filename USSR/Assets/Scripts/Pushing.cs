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
    public float xRotateAngles;
    public float yRotateAngles;
    public float zRotateAngles;

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
        feedback.color = Color.grey;                                //set the color to grey as default color
    }

   
    private void OnTriggerEnter(Collider other)             //When the collider is triggered
    {
        if (other.tag == "Player")                          //if the other object has the Player tag
        {
            catching.SetActive(true);                       //activate catching
            feedback.DOColor(Color.green, 1);       //change the color to green
            GetCaughtCubes();                              //run the GetCaughtCubes function
        }
    }

    private void OnTriggerExit(Collider other)              //when exiting the collider
    {
        if (other.tag == "Player")                          //if the other object has the Player tag
        {
            catching.SetActive(false);                      //deactivate catching
            feedback.DOColor(Color.grey, 1);        //change the color to the default color grey
            ReleaseCaughtCubes();                          //run the ReleaseCaughtCubes function
        }
    }

    private void OnTriggerStay(Collider other)              //while colliding
    {
        if (other.tag == "Player")                          //if the other object has the Player tag
        {
            if (Input.GetKeyDown(KeyCode.T) && canPush)                //and when the T key is pressed
            {
                Debug.Log("start to push");
                RotateSound.GetComponent<AudioSource>().Play();
                PushCaughtCubes();                          //run the PushCaughtCubes
            }
        }
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
        //rotate the object
        rotatePivot.DORotate(new Vector3(xRotateAngles +xRotateModifyer, 
            yRotateAngles + yRotateModifyer,
            zRotateAngles + zRotateModifyer),
            1,RotateMode.Fast);
        
        isRotate = true;    //set the object as rotated
    }

    public void ReleaseCaughtCubes() {
        catchedCubes.Clear();               //empty the catchedCubes list
    }

    public void Level1RedGreenDoorOpenCheck()
    {
        if(Level1RedGreenDoor.instance.canOpen)
        {
            Level1RedGreenDoor.instance.stopToOpen = true;
        }
    }

    private void Update()
    { //Debug stuff
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