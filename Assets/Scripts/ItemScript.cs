using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : Interactable
{
    public override void Interacted(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject.Find("ItemManager").GetComponent<ItemManager>().HandleInteraction(gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
