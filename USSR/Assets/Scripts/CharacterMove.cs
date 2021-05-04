using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used on player both level

public class CharacterMove : MonoBehaviour
{

    public static CharacterMove instance; //create an instance that is going to be used in another script

    //variables to control de sensitivity of the mouse movement
    public float mouseSensitivity = 1.0f;

    // variables to control the movement of the player
    public float walkSpeed = 10.0f;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    // variables to control the camera
    Transform cameraT;
    float verticalLookRotation;

    Rigidbody rigidbodyR;       //variable to store the rigidbody

    bool cursorVisible;         //variable to modify the curse 

    public bool isSetCubeAsParent; //level2: variable to decide whether player rotate with Cube

    public bool isReading;

    public GameObject currentGameobject;

    public Transform cameraTransform;


    private void Awake()
    {
        instance = this;	//make this objects the instance
    }
    // Use this for initialization
    void Start()
    {
        cameraT = Camera.main.transform;            //store the camara transform
        rigidbodyR = GetComponent<Rigidbody>(); //get the rigidbody component of the object
        LockMouse();                                // run the LockMouse function


    }

    // Update is called once per frame
    void Update()
    {

        // Move camera depending on the the mouse position
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        // Control the movement of the player, direction and speed
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        // run the Lock/unlock mouse function on click
        if (isReading)
        {
            UnlockMouse();
        }
        else
        {
            LockMouse();
        }

        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }

        RaycastHit hit;
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        if (Physics.Raycast(ray, out hit, 1f))
        {
            currentGameobject = hit.collider.gameObject;
            Debug.DrawLine(ray.origin, hit.point);
            if (currentGameobject.tag == "pushing")
            {
                currentGameobject.GetComponent<Pushing>().WhenPlayerEnter();
                if (Input.GetKeyDown(KeyCode.E) && currentGameobject.GetComponent<Pushing>().canPush)
                {
                    currentGameobject.GetComponent<Pushing>().PushCaughtCubes();
                }
            }
            if (currentGameobject.tag == "radio")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentGameobject.GetComponent<Radio>().ChangeRadioCameraState();
                }
            }
            if (currentGameobject.tag == "menu")
            {
                currentGameobject.GetComponent<ManualBook>().WhenPlayerEnter();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentGameobject.GetComponent<ManualBook>().ChangeMenuUIState();
                }
            }
            if(currentGameobject.tag == "level2statetrigger")
            {
                currentGameobject.GetComponent<StageTrigger>().WhenPlayerEnter();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentGameobject.GetComponent<StageTrigger>().OnInteract();
                }
            }
        }
        if (!Physics.Raycast(ray, out hit, 1f) || hit.collider.gameObject != currentGameobject)
        {
            if (currentGameobject == null)
            {
                return;
            }
            if (currentGameobject.tag == "pushing")
            {
                currentGameobject.GetComponent<Pushing>().WhenPlayerExit();
            }
            if (currentGameobject.tag == "menu")
            {
                currentGameobject.GetComponent<ManualBook>().WhenPlayerExit();
            }
            if (currentGameobject.tag == "level2statetrigger")
            {
                currentGameobject.GetComponent<StageTrigger>().WhenPlayerExit();
            }
            currentGameobject = null;
        }
    }

    // update the rigidbody to move as you are giving input of movement
    void FixedUpdate()
    {
        rigidbodyR.MovePosition(rigidbodyR.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);





    }

    //Unlock mouse and make it visible
    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorVisible = true;
    }
    //Lock mouse and make it invisible
    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorVisible = false;
    }

    // Code to prevent weird rotation when everything else is moving by having it move with the other object
    private void OnTriggerEnter(Collider other)
    {
        if (isSetCubeAsParent)
        {
            if (other.tag == "cube")
            {
                gameObject.transform.SetParent(other.gameObject.transform); //set the cube as parent of this object so it will rotate with it
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "stair")
        {   //when using stairs
            walkSpeed = 15;						//make speed faster so that is not so hard going up the stairs
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "stair")
        {   //when done with stairs 
            walkSpeed = 10;                     //reset speed
        }
    }
}

