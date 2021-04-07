using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	public static CharacterMove instance;
	//variables to control de sensitivity of the mouse movement
	public float mouseSensitivityX = 1.0f;
	public float mouseSensitivityY = 1.0f;

	// variables to control the movement of the player
	public float walkSpeed = 10.0f;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;

	// variables to control the camera
	Transform cameraT;
	float verticalLookRotation;

	Rigidbody rigidbodyR;		//variable to store the rigidbody
	
	bool cursorVisible;         //variable to modify the curse 

	public bool isSetCubeAsParent; //level2: variable to decide whether player rotate with Cube

    private void Awake()
    {
		instance = this;
    }
    // Use this for initialization
    void Start () {
		cameraT = Camera.main.transform;			
		rigidbodyR = GetComponent<Rigidbody> ();	//get the rigidbody component
		LockMouse ();								//lock mouse at the center
	}
	
	// Update is called once per frame
	void Update () {
		if(!RadioController.instance.isFocusing)
        {
			// Move camera depending on the the mouse position
			transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
			verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
			verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
			cameraT.localEulerAngles = Vector3.left * verticalLookRotation; //make sures that the player is moving according to the camera
		}
		else
		{
			cameraT.eulerAngles = Vector3.zero;
		}
		

		// Control the movement of the player, direction and speed
		Vector3 moveDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp (moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
		
		/* Lock/unlock mouse on click */
		if (Input.GetMouseButtonUp (0)) {
			if (!cursorVisible) {
				UnlockMouse ();
			} else {
				LockMouse ();
			}
		}
	}

	void FixedUpdate() {
		rigidbodyR.MovePosition (rigidbodyR.position + transform.TransformDirection (moveAmount) * Time.fixedDeltaTime);
	}

	//Unlock mouse and make it visible
	void UnlockMouse() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		cursorVisible = true;
	}
	//Lock mouse and make it invisible
	void LockMouse() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cursorVisible = false;
	}

	// Code to prevent weird rotation when everything else is moving by having it move with the other object
	private void OnTriggerEnter(Collider other) {
		if(isSetCubeAsParent)
        {
			if (other.tag == "cube")
			{
				gameObject.transform.SetParent(other.gameObject.transform);
			}
		}
	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "stair")
        {
			walkSpeed = 15;
        }
    }

    private void OnCollisionExit(Collision other)
    {
		if (other.gameObject.tag == "stair")
		{
			walkSpeed = 10;
		}
	}
}

