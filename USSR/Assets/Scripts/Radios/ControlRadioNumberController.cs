using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//radio codes for all levels with at least a radio
public class ControlRadioNumberController : MonoBehaviour
{
    public GameObject radio;    //variable fot the radio object
    public int numberOrder;     //variable for the digits
    public Text mtext;          //variable to control the text

    // Update is called once per frame
    void Update()
    {
        mtext.text = Level1ControlRadio.instance.numbers[numberOrder].ToString();

        if(numberOrder == Level1ControlRadio.instance.currentControllingNumber) {  //when controlling a number
            mtext.color = Color.red;                                            //make it red
        }
        else {                                                                  //when not controlling a number 
            mtext.color = Color.black;                                          //make it black
        }
    }
}
