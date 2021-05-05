using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextLevel : MonoBehaviour
{

    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive==true){
            int i=SceneManager.GetActiveScene().buildIndex;
                i=i+1;
                SceneManager.LoadScene(i,LoadSceneMode.Single);
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
