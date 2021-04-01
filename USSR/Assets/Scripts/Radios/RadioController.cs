using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public static RadioController instance;
    public Rigidbody playerRigidbody;

    public GameObject player;
    public GameObject playerCam;
    public Transform camPoint;

    //matches that play music
    public List<string> combos;
    //three number panel
    public List<GameObject> numbers;

    public GameObject currentContrillingNumber;
    public bool isFocusing;

    private Vector3 standardRotate;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFocusing)
        {
            playerCam.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(isFocusing)
            {
                playerCam.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
            Debug.Log("player");
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("staying");
                if(isFocusing)
                {
                    playerCam.transform.parent = player.transform;
                    playerCam.transform.localPosition = Vector3.zero;
                    playerCam.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    CharacterMove.instance.walkSpeed = 10;
                    CharacterMove.instance.mouseSensitivityX = 1;
                    CharacterMove.instance.mouseSensitivityY = 1;

                    playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    isFocusing = false;
                }
                else
                {
                    playerCam.transform.parent = camPoint;
                    playerCam.transform.position = camPoint.position;
                    playerCam.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    CharacterMove.instance.walkSpeed = 0;
                    CharacterMove.instance.mouseSensitivityX = 0;
                    CharacterMove.instance.mouseSensitivityY = 0;

                    playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    isFocusing = true;
                }
            }
        }
    }
}
