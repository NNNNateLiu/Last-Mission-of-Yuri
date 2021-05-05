using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingonLand : MonoBehaviour
{
    public GameObject PlayerPosition;
    public int boardingtime;
    public bool isActive;
    public AudioSource walkSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad>boardingtime){
          PlayerPosition.GetComponent<Animator>().enabled=false;
        }
        if(isActive==true){
            if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)){
                walkSound.Play();
            }
            else
            {
                walkSound.Pause();
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag=="Player")
        {
            isActive=false;
        }
    }
}
