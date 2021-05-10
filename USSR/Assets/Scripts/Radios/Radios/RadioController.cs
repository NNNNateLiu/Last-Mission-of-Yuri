using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : Radio
{

    //matches that play music
    public List<Music> music;

    public Text panel;
    // Start is called before the first frame update
    void Start()
    {
        maudio = gameObject.GetComponent<AudioSource>();
    }

    public override void AfterPressEnter()
    {
        for (var i = 0; i < music.Count; i++)
        {
            if (music[i].cambos == currentCombo)
            {
                Debug.Log("now playing: " + music[i]);
                maudio.clip = music[i].music;
                maudio.Play();
                break;
            }
            else
            {
                invalidCombo.Play();
            }
        }
    }
}
