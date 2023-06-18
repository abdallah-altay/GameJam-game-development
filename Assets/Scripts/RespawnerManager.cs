using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnerManager : MonoBehaviour
{
    private GameObject player;
    private Vector3 startPosition;
    public GameObject youWin;

    private void Awake()
    {
        player = GameObject.Find("Player");
        startPosition = gameObject.transform.GetChild(0).gameObject.transform.position;
        player.transform.position = startPosition;
    }

    public void Interacted(string objectName)
    {
        switch (objectName)
        {
            case "StartCollider":
                TriggeredStart();
                break;
            case "EndCollider":
                TriggeredEnd();
                break;
        }
    }
    public void TriggeredStart()
    {
        
    }

    public void ResetPlayerToSpawn()
    {
        Debug.Log("Reset");
        player.transform.position = startPosition;
    }

    public void TriggeredEnd()
    {
        Debug.Log(ItemInfo.hasItemLockpick);
        if(ItemInfo.hasItemLockpick == true)
        {
            youWin.SetActive(true);
        }
    }
}
