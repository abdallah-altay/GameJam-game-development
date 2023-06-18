using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentManager : MonoBehaviour
{
    public GameObject otherVent;
    public bool canTeleport;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.name == "Player" && canTeleport && ItemInfo.hasItemScrewdriver)
        {
            otherVent.GetComponent<VentManager>().canTeleport = false;
            TeleportToOtherVent(other.transform.gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        canTeleport = true;
    }

    public void TeleportToOtherVent(GameObject player)
    {
        Vector3 teleportTo = new Vector3(0,0,0);
        teleportTo = otherVent.transform.position;
        Debug.Log(otherVent.transform.localEulerAngles.z);
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
