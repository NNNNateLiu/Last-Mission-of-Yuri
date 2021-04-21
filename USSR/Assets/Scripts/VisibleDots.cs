using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleDots : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite spr;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = null;
    }
    
    // private void OnCollisionEnter(Collision other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("VisibilityWall"))
        {
            //gameObject.SetActive(true);
            sr.sprite = spr;
        }
    }

    //private void OnCollisionExit(Collision other)
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("VisibilityWall"))
        {
           // gameObject.SetActive(false);
            sr.sprite = null;
        }
    }
}
