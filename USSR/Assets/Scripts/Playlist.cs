using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{   public AudioClip[] MusicAmount;
    public int MusicNumber;
    public GameObject MusicList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playlist(){
        
        MusicList.GetComponent<AudioSource>().clip=MusicAmount[MusicNumber];
    }
    public void playmusic(){
        gameObject.GetComponent<AudioSource>().Play();
    }
}
