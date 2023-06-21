using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPlayerDetector : MonoBehaviour
{
    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.parent.gameObject.name == "GuardFOV")
        {
            other.gameObject.transform.parent.GetChild(2).GetComponent<GuardMovement>().ResetPlayer();
        }
    }
}
