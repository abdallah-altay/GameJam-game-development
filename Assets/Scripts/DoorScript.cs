using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    private bool notOpened = true;
    public override void Interacted(Collider2D other)
    {
        if (GameObject.Find("ItemManager").GetComponent<ItemManager>().CheckCanOpen(gameObject.name) && notOpened)
        {
            Debug.Log("Opened!");
            notOpened = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
