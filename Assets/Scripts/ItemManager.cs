using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private GameObject itemSlots;

    public void Awake()
    {
        itemSlots = GameObject.Find("ItemHud");
    }

    public void AddImageIcon(string name)
    {
        switch (name)
        {
            case "Item Lockpick":
                ItemInfo.hasItemLockpick = true;
                itemSlots.transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
                break;
            case "Item Screwdriver":
                ItemInfo.hasItemScrewdriver = true;
                itemSlots.transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
                break;
            case "Item Car Keys":
                ItemInfo.hasItemCarKeys = true;
                itemSlots.transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = true;
                break;
        }
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
            case "Vent":
                if (ItemInfo.hasItemLockpick)
                {
                    canOpen = true;
                }
                break;
            case "Vechile":
                if (ItemInfo.hasItemLockpick)
                {
                    canOpen = true;
                }
                break;
        }
        return canOpen;
    }
}
