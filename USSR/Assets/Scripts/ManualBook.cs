using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualBook : MonoBehaviour

{   public bool isActive;
    public GameObject Canvas;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { if(isActive==true){
        if(Input.GetKeyDown(KeyCode.R)){
            Canvas.SetActive(true);
            Canvas.GetComponent<AudioSource>().Play();
            
        }
    }
        
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag=="Player"){
            isActive=true;

        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag=="Player"){
            isActive=false;
        }
    }
    public void closeUI(){
       Time.timeScale=1;
       Canvas.SetActive(false);
    }
}
