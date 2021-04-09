using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used on the player from the first level, for some reason is not used on the player of the 2second scene
public enum RotationAxes { 
    MouseXAndY = 0, MouseX = 1, MouseY = 2 
}
public class CameraMove : MonoBehaviour {

    public static CameraMove instance;
    
    //if x and y are the same number can we combine them into 1 variable
    //x轴（水平）速度
    public float sensitivityX = 15F;    
    //y轴（垂直）速度
    public float sensitivityY = 15F;
   
    //these are not being used
    //x轴（水平）最小旋转值
    public float minimumX = -360F;
    //x轴（水平）最大旋转值
    public float maximumX = 360F;
    
    //kind of the same here, is the same number but one negative one positive, wouldn't it be better to have one variable and add the "-" to the code that needs to be negative
    //y轴（垂直）最小旋转值
    public float minimumY = -60F;
    //y轴（垂直）最大旋转值
    public float maximumY = 60F;
    
    
    //旋转轴
    public RotationAxes axes = RotationAxes.MouseXAndY;
    private float rotationY = 0F;

    private void Awake() {
        instance = this;    //what is doing? like i know what the code is doing but why do we need it done?
    }
    void Update ()
    {   // Determine limits of camera
        if (axes == RotationAxes.MouseXAndY) { //why do we need one scenario for when the player is moving on both the aces and one for each individual axes
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        
        else if (axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        
        else if (axes == RotationAxes.MouseY) {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
	
    void Start () {
        Cursor.visible = false; //make the curse invisible
    }
}
