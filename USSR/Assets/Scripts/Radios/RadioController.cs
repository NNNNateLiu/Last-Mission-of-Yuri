using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    public static RadioController instance;
    public Rigidbody playerRigidbody;

    public GameObject radioCam;
    public GameObject player;
    public GameObject playerCam;
    public Transform camPoint;

    //matches that play music
    public List<string> combos;
    public List<AudioClip> music;
    public List<string> titles;
    public List<int> numbers;
    public string currentCombo;

    public int currentControllingNumber = 0;
    public bool isFocusing;

    private Vector3 standardRotate;
    private AudioSource maudio;

    public Text panel;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        maudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   //control the radio
        if (isFocusing) //when using the radio
        {
            if(Input.GetKeyDown(KeyCode.UpArrow)) //after pressing the up arrow key 
            {
                numbers[currentControllingNumber]++;        //add one to the current number
                if(numbers[currentControllingNumber] > 9)   //if number bigger than 9
                {
                    numbers[currentControllingNumber] = 0;  //change number to 0
                }
                currentCombo = numbers[0].ToString() + numbers[1].ToString() + numbers[2].ToString(); //update the combo
            }

            if (Input.GetKeyDown(KeyCode.DownArrow)) //after pressing the down arrow  key 
            {
                numbers[currentControllingNumber]--;        //substract one to the current number
                if (numbers[currentControllingNumber] < 0)   //if number lesser than 0
                {
                    numbers[currentControllingNumber] = 9;       //change number to 9
                }
                currentCombo = numbers[0].ToString() + numbers[1].ToString() + numbers[2].ToString();//update the combo
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))    //after pressing left arrow key
            {
                currentControllingNumber--;             //select the number on the left slot of current selected number
                if(currentControllingNumber < 0)        //if you are on the far left 
                {
                    currentControllingNumber = 2;       //select the far right slot
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))    //after pressing right arrow key
            {
                currentControllingNumber++;              //select the number on the right slot of current selected number
                if (currentControllingNumber > 2)        //if you are on the far right 
                {
                    currentControllingNumber = 0;       //select the far left slot
                }
            }

            if(Input.GetKeyDown(KeyCode.Return))             //after pressing p
            {
                Debug.Log("play");
                
                //check the string and play the music or recording depending on the string
                for(var i = 0; i < combos.Count; i++ )  
                {
                    if (combos[i] == currentCombo)
                    {
                        maudio.clip = music[i];
                        maudio.Play();
                        panel.text = titles[i];
                        break;
                    }
                }
            }

        }

    }


    //it does something related to determining if the player is focusing or not on the radio and how the camera acts in both posibilies
    //my brain hurts from trying to fully understand this
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("staying");
                if(isFocusing)
                {
                    playerCam.SetActive(true);
                    radioCam.SetActive(false);
                    CharacterMove.instance.walkSpeed = 10;
                    CharacterMove.instance.mouseSensitivity = 1;

                    playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                    isFocusing = false;
                }
                else
                {
                    playerCam.SetActive(false);
                    radioCam.SetActive(true);
                    CharacterMove.instance.walkSpeed = 0;
                    CharacterMove.instance.mouseSensitivity = 0;

                    playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    isFocusing = true;
                }
            }
        }
    }
}
