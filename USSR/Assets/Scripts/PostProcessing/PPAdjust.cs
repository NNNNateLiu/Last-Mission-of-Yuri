using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPAdjust : MonoBehaviour
{ 
  public GameObject SwitchPP;
  public GameObject OldPP;
  public GameObject NewPP;
  public GameObject Light;
  public GameObject Sounds;
  public GameObject NewSounds;

    public void SwitchPostProcessing()
    {
        SwitchPP.SetActive(true);
        OldPP.SetActive(false);
        NewPP.SetActive(true);
        Light.SetActive(true);
        Sounds.SetActive(false);
        NewSounds.SetActive(true);
    }
}
