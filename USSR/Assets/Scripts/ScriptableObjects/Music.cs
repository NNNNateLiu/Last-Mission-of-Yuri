using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music in Radio",
    menuName = "ScriptableObjects/Music", order = 0)]

public class Music : ScriptableObject
{
    public string cambos;
    public AudioClip music;
}
