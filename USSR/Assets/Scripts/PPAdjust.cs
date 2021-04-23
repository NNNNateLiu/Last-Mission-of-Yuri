using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPAdjust : MonoBehaviour
{ public GameObject DoorTrigger;
  public GameObject SwitchPP;
  public GameObject OldPP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DoorTrigger.GetComponent<Level1RedGreenDoor>().stopToOpen){
            SwitchPP.SetActive(true);
            OldPP.SetActive(false);

          }
        
    }
}
