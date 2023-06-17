using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] guards;
    public void ActivatePowerup(string name)
    {
        switch (name)
        {
            case "Invisible":
                InvisibleActivation(name);
                break;
            case "Blind":
                BlindActivation(name);
                break;
        }
    }

    public void InvisibleActivation(string name)
    {
        Debug.Log("IsInvisible");
        ItemInfo.isInvisible = true;
        Color temp = player.GetComponent<SpriteRenderer>().color;
        temp.a = (float)0.5;
        player.GetComponent<SpriteRenderer>().color = temp;
        StartCoroutine(Countdown(5, name));
    }

    public void InvisibleEnd()
    {
        Debug.Log("IsNotInvisible");
        ItemInfo.isInvisible = false;
        Color temp = player.GetComponent<SpriteRenderer>().color;
        temp.a = (float)1;
        player.GetComponent<SpriteRenderer>().color = temp;
    }

    public void BlindActivation(string name)
    {
        guards = GameObject.FindGameObjectsWithTag("Guard");
        foreach(GameObject guard in guards)
        {
            guard.transform.GetChild(1).gameObject.SetActive(false);
        }
        StartCoroutine(Countdown(5, name));
    }

    public void BlindEnd()
    {
        guards = GameObject.FindGameObjectsWithTag("Guard");
        foreach (GameObject guard in guards)
        {
            guard.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    IEnumerator Countdown(int seconds, string name)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        switch (name)
        {
            case "Invisible":
                InvisibleEnd();
                break;
            case "Blind":
                BlindEnd();
                break;
        }
    }

}
