using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level3StageTrigger : StageTrigger
{
    public override void OnInteract()
    {
        doorCollider.transform.DOLocalMoveZ(-8f, 3f);
    }
}
