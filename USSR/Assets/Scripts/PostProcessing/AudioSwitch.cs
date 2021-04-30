using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour

{
    public GameObject bgm;
    public bool isActive;
    public bool isPlay;
    private static float volume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        AudioSource music=bgm.GetComponent<AudioSource>();
        if(isActive==true){
          while (volume<1){
            bgm.SetActive(true);
            volume=music.volume;
            volume+=0.001f;
            music.volume=Mathf.Lerp(music.volume,volume,1f * Time.deltaTime);
        }
        if (music.isPlaying){
            isPlay=true;
        }
        }
        else{
            while(volume>0){
                volume=music.volume;
                volume-=0.001f;
                music.volume=Mathf.Lerp(music.volume,volume,1f*Time.deltaTime);
            }
            if(volume<0.01){
                bgm.SetActive(false);
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag=="Player")
        {
            isActive=false;
        }
    }
}
