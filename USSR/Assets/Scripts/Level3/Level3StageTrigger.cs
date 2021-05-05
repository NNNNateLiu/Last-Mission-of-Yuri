using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3StageTrigger : StageTrigger
{
    public override void OnInteract()
    {
        doorCollider.SetActive(false);
    }
}
