using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : Interactable
{
    public override void Interacted(Collider2D other)
    {
        GameObject.Find("ItemManager").GetComponent<ItemManager>().AddImageIcon(gameObject.name);
        Destroy(this.gameObject);
    }
}
