using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WalkSpeedDown : MonoBehaviour
{
    public GameObject Playerposition;
    public GameObject Portalposition;
    public GameObject PlayerCamera;
    public bool isActive;
    public float distance;
    public GameObject Transit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance=-Playerposition.transform.localPosition.x+Portalposition.transform.localPosition.x-169f;
        if(isActive==true){
            Playerposition.GetComponent<CharacterMove>().walkSpeed=distance*8f;
            PlayerCamera.GetComponent<Camera>().fieldOfView=distance*95f;
            Transit.GetComponent<Image>().color=new Color(251,255,239,0.03f/distance);
            if(distance<=0.035){
                int i=SceneManager.GetActiveScene().buildIndex;
                i=i+1;
                SceneManager.LoadScene(i,LoadSceneMode.Single);
            }
            
        }
        else{
            Playerposition.GetComponent<CharacterMove>().walkSpeed=5;
            PlayerCamera.GetComponent<Camera>().fieldOfView=60;
        }
        
        
    }

    private void OnTriggerStay( Collider other){

        if (other.tag == "Player"){

            isActive=true;
        }
    }
    private void OnTriggerExit( Collider other){

        if (other.tag == "Player"){

            isActive=false;
        }
    }
}
