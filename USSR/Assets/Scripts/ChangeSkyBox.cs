using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyBox : MonoBehaviour
{

    public bool isActive;
    public Material SkyboxUpdate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive==true){
            RenderSettings.skybox=SkyboxUpdate; 

        }
    }
    private void OnTriggerEnter(Collider other){

        if(other.tag=="Player"){

            isActive=true;
        }
    }
}
