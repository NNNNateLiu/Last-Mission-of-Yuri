using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActive : MonoBehaviour
{
    public GameObject GameCollider;
    public AudioSource OpenAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameCollider.activeSelf==false){
            OpenAudio.Play();
        }
        
    }
}
