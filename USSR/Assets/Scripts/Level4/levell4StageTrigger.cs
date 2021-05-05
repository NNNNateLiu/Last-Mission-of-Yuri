using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class levell4StageTrigger : StageTrigger
{
    public Animator doorAnim;
    public override void OnInteract()
    {
        doorAnim.SetBool("CanRotate", true);
    }
}
