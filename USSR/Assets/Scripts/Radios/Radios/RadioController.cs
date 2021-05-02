using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : Radio
{

    //matches that play music
    public List<string> combos;
    public List<AudioClip> music;
    public List<string> titles;

    private AudioSource maudio;

    public Text panel;
    // Start is called before the first frame update
    void Start()
    {
        maudio = gameObject.GetComponent<AudioSource>();
    }

    public override void AfterPressEnter()
    {
        for (var i = 0; i < combos.Count; i++)
        {
            if (combos[i] == currentCombo)
            {
                Debug.Log("now playing: " + music[i]);
                maudio.clip = music[i];
                maudio.Play();
                panel.text = titles[i];
                break;
            }
        }
    }
}
