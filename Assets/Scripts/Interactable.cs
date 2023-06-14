using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Interacted(other);
    }

    public virtual void Interacted(Collider2D other)
    {

    }
}
