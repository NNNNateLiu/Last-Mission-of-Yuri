using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControVideo : MonoBehaviour
{
    public bool isActive;
    public VideoPlayer news;
    public GameObject Screen;
    public Material Original;
    public Material Glass;
    public bool stopPlaying;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive==true){
          news.Play();

          Screen.GetComponent<MeshRenderer>().material=Glass;
          if(news.isPlaying==false){
              stopPlaying=true;
              gameObject.GetComponent<ControVideo>().enabled=false;
          }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            isActive = true;
        }
    }
}
