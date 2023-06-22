using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentManager : MonoBehaviour
{
    public GameObject otherVent;
    public bool canTeleport = false;
    public GameObject player;
    public GameObject helpTip;

    public void Awake()
    {
        canTeleport = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            canTeleport = true;
            helpTip.SetActive(true);
        }

    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            canTeleport = false;
            helpTip.SetActive(false);
        }
    }

    void Update()
    {
        if (canTeleport && ItemInfo.hasItemScrewdriver && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Entered Vent");
            otherVent.GetComponent<VentManager>().canTeleport = false;
            TeleportToOtherVent();
        }
    }

    public void TeleportToOtherVent()
    {
        Vector3 teleportTo = new Vector3(0,0,0);
        teleportTo = otherVent.transform.position;
        Debug.Log(teleportTo);
        switch (otherVent.transform.localEulerAngles.z)
        {
            case 0:
                teleportTo.x += 0.5f;
                break;
            case 90:
                teleportTo.y += 0.5f;
                break;
            case 180:
                teleportTo.x -= 0.5f;
                break;
            case 270:
                teleportTo.y -= 0.5f;
                break;
        }
        player.transform.position = teleportTo;
    }
}
