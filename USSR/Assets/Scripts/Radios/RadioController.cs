using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RadioController : MonoBehaviour
{
    public static RadioController instance;
    public Rigidbody playerRigidbody;

    public GameObject player;
    public GameObject playerCam;
    public Transform camPoint;

    public GameObject pointer;
    private float pointerChangeValue;
    private float currentPointerValue = -50f;
    private float pointerColdDown = 1f;
    private float pointerTimer;
    public bool canPlay;

    //matches that play music
    public List<string> combos;
    public List<AudioClip> music;
    public List<string> titles;
    public List<int> numbers;
    public string currentCombo;

    public int currentContrillingNumber = 0;
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
    {
        if (isFocusing)
        {
            playerCam.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                numbers[currentContrillingNumber]++;
                if(numbers[currentContrillingNumber] > 9)
                {
                    numbers[currentContrillingNumber] = 0;
                }
                currentCombo = numbers[0].ToString() + numbers[1].ToString() + numbers[2].ToString();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                numbers[currentContrillingNumber]--;
                if (numbers[currentContrillingNumber] < 0)
                {
                    numbers[currentContrillingNumber] = 9;
                }
                currentCombo = numbers[0].ToString() + numbers[1].ToString() + numbers[2].ToString();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentContrillingNumber--;
                if(currentContrillingNumber < 0)
                {
                    currentContrillingNumber = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentContrillingNumber++;
                if (currentContrillingNumber > 2)
                {
                    currentContrillingNumber = 0;
                }
            }

            if(Input.GetKeyDown(KeyCode.P) && canPlay)
            {
                int currentComboNumber = int.Parse(currentCombo);
                pointerChangeValue = (80 * currentComboNumber) / 1000;
                currentPointerValue = -50 - pointerChangeValue;
                pointer.transform.DOLocalRotate(new Vector3(0, 0, currentPointerValue), 1, RotateMode.Fast);

                Debug.Log("play");
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

    public void NumberSwitchUp(int currentNumber)
    {
        numbers[currentNumber]++;
    }

    public void NumberSwitchDwon(int currentNumber)
    {
        numbers[currentNumber]--;
    }
}
