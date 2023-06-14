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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.name == "Player")
        {
            this.gameObject.GetComponent<GuardMovement>().ResetPlayer();
        }
    }
}
