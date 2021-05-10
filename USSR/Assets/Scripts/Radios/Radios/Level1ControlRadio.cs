using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1ControlRadio : Radio
{
    public GameObject pushings;
    public GameObject LightSource;

    public override void AfterPressEnter()
    {
        if(currentCombo == rightCombo)
        {
            pushings.SetActive(true);
            ChangeRadioCameraState();
            //just let it disappear for now
            gameObject.SetActive(false);
            //play the active sound
            correctCombo.Play();
            //Turnoff the light
            LightSource.SetActive(false);
        }
        else{
            invalidCombo.Play();
        }
    }
}
