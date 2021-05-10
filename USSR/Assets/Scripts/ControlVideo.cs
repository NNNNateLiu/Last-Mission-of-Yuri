using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlVideo : MonoBehaviour
{
    public bool isActive;
    public VideoPlayer news;
    public GameObject Screen;
    public Material Original;
    public Material Glass;

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            Screen.SetActive(false);
            news.Play();
            if(!news.isPlaying)
            {
                Screen.GetComponent<MeshRenderer>().material = Original;
                gameObject.GetComponent<ControlVideo>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = true;
        }
    }
}
