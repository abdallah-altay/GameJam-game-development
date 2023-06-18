using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.gameObject.name == "Player")
        {
            GameObject.Find("PowerUpManager").GetComponent<PowerupManager>().ActivatePowerup(gameObject.name);
            Destroy(gameObject);
        }
    }
}
