using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInteracted : Interactable
{
    public override void Interacted(Collider2D other)
    {
        transform.parent.GetComponent<RespawnerManager>().Interacted(gameObject.name);
    }
}
