using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderListener : MonoBehaviour
{

    void Awake()
    {
        // Check if Colider is in another GameObject
        Collider2D collider = GetComponentInChildren<Collider2D>();
        if (collider.gameObject != gameObject)
        {
            ColliderBridge cb = collider.gameObject.AddComponent<ColliderBridge>();
            cb.Initialize(this);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.name == "StartCollider" || this.gameObject.name == "EndCollider")
        {
            this.gameObject.GetComponent<RespawnerManager>().Interacted(gameObject.name);
        }
        if (other.transform.gameObject.name == "Player" && this.gameObject.name == "Guard")
        {
            this.gameObject.GetComponent<GuardMovement>().ResetPlayer();
        }
    }
}
