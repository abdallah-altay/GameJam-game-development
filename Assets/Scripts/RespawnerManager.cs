using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RespawnerManager : MonoBehaviour
{
    private GameObject player;
    private Vector3 startPosition;
    public GameObject youWin;
    private Scene scene;
    private ItemManager itemManager;
    public GameObject itemsPrefab;
    private GameObject items;

    private void Awake()
    {
        player = GameObject.Find("Player");
        items = GameObject.Find("Items");
        startPosition = gameObject.transform.GetChild(0).gameObject.transform.position;
        player.transform.position = startPosition;
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        if (ItemInfo.hasItemLockpick)
        {
            itemManager.SetItemVisualTrue(0);
        }
        if (ItemInfo.hasItemScrewdriver)
        {
            itemManager.SetItemVisualTrue(1);
        }
        if (ItemInfo.hasItemCarKeys)
        {
            itemManager.SetItemVisualTrue(2);
        }
    }

    public void Interacted(string objectName)
    {
        if(objectName == "EndCollider")
        {
            TriggeredEnd();
        }
    }

    public void ResetPlayerToSpawn()
    {
        Debug.Log("Reset");
        player.transform.position = startPosition;
        if(scene.name == "Main")
        {
            itemManager.SetItemVisualFalse(0);
            itemManager.SetItemVisualFalse(1);
            ItemInfo.hasItemLockpick = false;
            ItemInfo.hasItemScrewdriver = false;
        }
        if (scene.name == "Level2")
        {
            itemManager.SetItemVisualFalse(2);
            ItemInfo.hasItemCarKeys = false;
        }
        
        Destroy(items);
        Instantiate(itemsPrefab);
    }

    public void TriggeredEnd()
    {
        if((scene.name == "Main" && ItemInfo.hasItemLockpick) || 
            (scene.name == "Level2" && ItemInfo.hasItemCarKeys))
        {
            youWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ChangeScene()
    {
        if (scene.name == "Main")
        {
            SceneManager.LoadScene("Level2");
        }
        if (scene.name == "Level2")
        {
            SceneManager.LoadScene("MainMenu");
            ItemInfo.hasItemLockpick = false;
            ItemInfo.hasItemScrewdriver = false;
            ItemInfo.hasItemCarKeys = false;
        }
    }
}
