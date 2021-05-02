using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1ControlRadio : Radio
{
    public GameObject pushings;
    public AudioSource correctCombo;
    public AudioSource invalidCombo;

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
        }
        else{
            invalidCombo.Play();
        }
    }
}
