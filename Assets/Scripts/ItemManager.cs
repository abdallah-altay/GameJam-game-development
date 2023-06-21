using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private GameObject itemSlots;
    public GameObject guards;
    public GuardMovement[] guardMovements;
    public GameObject player;

    public void Awake()
    {
        itemSlots = GameObject.Find("ItemHud");
        guardMovements = guards.GetComponentsInChildren<GuardMovement>();
    }

    public void HandleInteraction(string name)
    {
        switch (name)
        {
            case "Item Lockpick":
                ItemInfo.hasItemLockpick = true;
                SetItemVisualTrue(0);
                break;
            case "Item Screwdriver":
                ItemInfo.hasItemScrewdriver = true;
                SetItemVisualTrue(1);
                break;
            case "Item Car Keys":
                ItemInfo.hasItemCarKeys = true;
                SetItemVisualTrue(2);
                break;
            case "Freeze Potion":
                foreach(var guard in guardMovements)
                {
                    guard.canMove = false;
                }
                break;
            case "Speed Potion":
                player.GetComponent<playerController>().speedBuff = true;
                break;
        }
    }

    public void SetItemVisualTrue(int child)
    {
        itemSlots.transform.GetChild(child).GetChild(0).GetComponent<Image>().enabled = true;
    }

    public bool CheckCanOpen(string name)
    {
        bool canOpen = false;
        switch (name)
        {
            case "Door":
                if (ItemInfo.hasItemLockpick)
                {
                    canOpen = true;
                }
                break;
        }
        return canOpen;
    }
}
