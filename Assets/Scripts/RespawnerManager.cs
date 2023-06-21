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

    private void Awake()
    {
        player = GameObject.Find("Player");
        startPosition = gameObject.transform.GetChild(0).gameObject.transform.position;
        player.transform.position = startPosition;
        scene = SceneManager.GetActiveScene();
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
            Debug.Log("You Win");
        }
    }
}
