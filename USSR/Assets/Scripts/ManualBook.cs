using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualBook : MonoBehaviour

{   public bool isFocusing;
    public GameObject Canvas;
    public GameObject menu;
    public GameObject feedbackLight;
    public GameObject player;
    public Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)             
    {
        if (other.tag == "Player")                      
        {
            feedbackLight.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)          
    {
        if (other.tag == "Player")                          
        {
            feedbackLight.SetActive(false);
            
        }
    }

    private void OnTriggerStay(Collider other)              //while colliding
    {
        if (other.tag == "Player")
        {
            if (isFocusing)
            {

            }
            Debug.Log("player");
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("staying");
                if (isFocusing)
                {
                    CharacterMove.instance.walkSpeed = 10;
                    CharacterMove.instance.mouseSensitivity = 1;
                    playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    isFocusing = false;
                    CharacterMove.instance.isReading = false;
                    Canvas.SetActive(false);
                }
                else
                {
                    CharacterMove.instance.walkSpeed = 0;
                    CharacterMove.instance.mouseSensitivity = 0;
                    playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    isFocusing = true;
                    CharacterMove.instance.isReading = true;
                    Canvas.SetActive(true);
                    Canvas.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
    public void closeUI()
    {
        Time.timeScale = 1;

        

    }
}
